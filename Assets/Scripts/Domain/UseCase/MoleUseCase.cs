using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.UseCase
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

            // 処理実行の処理を登録
            moleEntity.Show = () => MolePresenter.Show(moleEntity.Index);
            moleEntity.Hide = () => MolePresenter.Hide(moleEntity.Index);
            moleEntity.Feint = () => MolePresenter.Feint(moleEntity.Index);
            moleEntity.Hit = () => MolePresenter.Hit(moleEntity.Index);
            moleEntity.CanAttack = () => MolePresenter.CanAttack(moleEntity.Index);

            // 有効無効切り替え時の処理を登録
            moleEntity.DidActiveSubject.Subscribe(_ => MolePresenter.Activate(moleEntity.Index));
            moleEntity.WillInactiveSubject.Subscribe(_ => MolePresenter.Deactivate(moleEntity.Index));

            // アニメーション後の処理を登録
            MolePresenter.WillShowAsObservable(moleEntity.Index).Subscribe(moleEntity.WillActiveSubject);
            MolePresenter.WillHideAsObservable(moleEntity.Index).Subscribe(moleEntity.WillInactiveSubject);
            MolePresenter.WillFeintAsObservable(moleEntity.Index).Subscribe(moleEntity.WillInactiveSubject);
            MolePresenter.WillHitAsObservable(moleEntity.Index).Subscribe(moleEntity.WillInactiveSubject);
            MolePresenter.DidShowAsObservable(moleEntity.Index).Subscribe(moleEntity.DidActiveSubject);
            MolePresenter.DidHideAsObservable(moleEntity.Index).Subscribe(moleEntity.DidInactiveSubject);
            MolePresenter.DidFeintAsObservable(moleEntity.Index).Subscribe(moleEntity.DidInactiveSubject);
            MolePresenter.DidHitAsObservable(moleEntity.Index).Subscribe(); // 即時 Hide に流れるので何もしない

            // 攻撃時の処理を登録
            MolePresenter.AttackAsObservable(moleEntity.Index).Subscribe(_ => moleEntity.Hit());
        }
    }
}