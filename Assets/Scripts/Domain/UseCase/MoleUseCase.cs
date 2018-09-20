using CAFU.Core;
using ExtraUniRx;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleUseCase : IUseCase
    {
    }

    public class MoleUseCase : IMoleUseCase, IInitializable
    {
        [Inject] private IFactory<int, IMoleEntity> MoleEntityFactory { get; }

        [Inject] private ITranslator<IMoleEntity, IGameStateEntity, IMole> MoleStructureTranslator { get; }

        [Inject] private IMolePresenter MolePresenter { get; }

        [Inject] private IGameStateEntity GameStateEntity { get; }

        [Inject] private IScoreEntity ScoreEntity { get; }

        [InjectOptional(Id = Constant.InjectId.MoleAmount)] private int MoleAmount { get; } = Constant.MoleAmount;

        public void Initialize()
        {
            for (var i = 0; i < MoleAmount; i++)
            {
                InitializeMole(MoleEntityFactory.Create(i));
            }
        }

        private void InitializeMole(IMoleEntity moleEntity)
        {
            // View の生成
            MolePresenter.Instantiate(moleEntity.Index, MoleStructureTranslator.Translate(moleEntity, GameStateEntity));

            // ゲーム全体のステータスに連動した処理を登録
            GameStateEntity.WillStartSubject.Subscribe(_ => moleEntity.Start());
            GameStateEntity.WillFinishSubject.Subscribe(_ => moleEntity.Finish());

            // 自身のインデックスと同じ
            GameStateEntity
                .AttackSubject
                .WhenDid()
                .Where(x => x == moleEntity.Index)
                .Subscribe(_ => moleEntity.HitSubject.Do());
        }
    }
}