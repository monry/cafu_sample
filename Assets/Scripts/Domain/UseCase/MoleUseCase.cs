using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleUseCase
    {
    }

    public class MoleUseCase : IMoleUseCase, IInitializable
    {
        [Inject] private PlaceholderFactory<int, IMoleEntity> MoleEntityFactory { get; }

        [Inject] private IMolePresenter MolePresenter { get; }

        [Inject] private IGameStateEntity GameStateEntity { get; }

        public void Initialize()
        {
            for (var i = 0; i < Constant.MoleAmount; i++)
            {
                InitializeMole(MoleEntityFactory.Create(i));
            }
        }

        private void InitializeMole(IMoleEntity moleEntity)
        {
            // View の生成
            MolePresenter.Instantiate(moleEntity.Index);

            // ゲーム全体のステータスに連動した処理を登録
            GameStateEntity.WillStartSubject.Subscribe(_ => moleEntity.Start());
            GameStateEntity.WillFinishSubject.Subscribe(_ => moleEntity.Finish());

            var moleStateStructure = MolePresenter.GenerateStateStructure(moleEntity.Index);
            var moleActivationStructure = MolePresenter.GenerateActivationStructure(moleEntity.Index);
            var moleAttackStructure = MolePresenter.GenerateAttackStructure(moleEntity.Index);

            // 処理実行の処理を登録
            moleEntity.Show = () => moleStateStructure.Show();
            moleEntity.Hide = () => moleStateStructure.Hide();
            moleEntity.Feint = () => moleStateStructure.Feint();
            moleEntity.Hit = () => moleStateStructure.Hit();
            moleEntity.CanAttack = () => moleAttackStructure.CanAttack();

            // 有効無効切り替え時の処理を登録
            moleEntity.DidActiveSubject.Subscribe(_ => moleActivationStructure.Activate());
            moleEntity.WillInactiveSubject.Subscribe(_ => moleActivationStructure.Deactivate());

            // アニメーション後の処理を登録
            moleStateStructure.WillShowObservable.Subscribe(moleEntity.WillActiveSubject);
            moleStateStructure.WillHideObservable.Subscribe(moleEntity.WillInactiveSubject);
            moleStateStructure.WillFeintObservable.Subscribe(moleEntity.WillInactiveSubject);
            moleStateStructure.WillHitObservable.Subscribe(moleEntity.WillInactiveSubject);
            moleStateStructure.DidShowObservable.Subscribe(moleEntity.DidActiveSubject);
            moleStateStructure.DidHideObservable.Subscribe(moleEntity.DidInactiveSubject);
            moleStateStructure.DidFeintObservable.Subscribe(moleEntity.DidInactiveSubject);
            moleStateStructure.DidHitObservable.Subscribe(); // 即時 Hide に流れるので何もしない

            // 攻撃時の処理を登録
            moleAttackStructure.AttackObservable.Subscribe(_ => moleEntity.Hit());
        }
    }
}