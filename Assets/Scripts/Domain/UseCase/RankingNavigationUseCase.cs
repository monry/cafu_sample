using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class RankingNavigationUseCase : IUseCase, IInitializable
    {
        [Inject] private IRankingRenderable RankingRenderable { get; }
        [Inject] private ITranslator<IResultListEntity, IRankingList> RankingStructureTranslator { get; }
        [Inject] private AsyncSubject<IResultListEntity> RankingEntitySubject { get; }

        void IInitializable.Initialize()
        {
            RankingEntitySubject
                .Select(RankingStructureTranslator.Translate)
                .Subscribe(RankingRenderable.RenderRanking);
        }
    }
}