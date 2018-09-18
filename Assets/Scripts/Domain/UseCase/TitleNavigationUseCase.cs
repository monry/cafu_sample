using CAFU.Core;
using CAFU.Scene.Domain.Entity;
using Monry.CAFUSample.Application.Enumerate;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface ITitleNavigationUseCase : IUseCase
    {
    }

    public class TitleNavigationUseCase : ITitleNavigationUseCase,
        IInitializable
    {
        [Inject] private ITitleNavigator TitleNavigator { get; }
        [Inject] private IRequestEntity RequestEntity { get; }

        void IInitializable.Initialize()
        {
            TitleNavigator.OnNavigateToGameAsObservable().Subscribe(_ => NavigateToGame());
            TitleNavigator.OnNavigateToRankingAsObservable().Subscribe(_ => NavigateToRanking());
        }

        private void NavigateToGame()
        {
            RequestEntity.RequestLoad(SceneName.SampleGame.ToString());
            RequestEntity.RequestUnload(SceneName.SampleTitle.ToString());
        }

        private void NavigateToRanking()
        {
            RequestEntity.RequestLoad(SceneName.SampleRanking.ToString());
            RequestEntity.RequestUnload(SceneName.SampleTitle.ToString());
        }
    }
}