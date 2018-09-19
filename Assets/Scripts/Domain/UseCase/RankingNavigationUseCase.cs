using CAFU.Core;
using CAFU.Scene.Domain.Entity;
using Monry.CAFUSample.Application.Enumerate;
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
        [Inject] private IRankingNavigator RankingNavigator { get; }
        [Inject] private IRequestEntity RequestEntity { get; }

        void IInitializable.Initialize()
        {
            RankingEntitySubject
                .Select(RankingStructureTranslator.Translate)
                .Subscribe(RankingRenderable.RenderRanking);
            RankingNavigator.OnNavigateToTitleAsObservable().Subscribe(_ => NavigateToTitle());
        }

        private void NavigateToTitle()
        {
            RequestEntity.RequestLoad(SceneName.SampleTitle.ToString());
            RequestEntity.RequestUnload(SceneName.SampleRanking.ToString());
        }
    }
}