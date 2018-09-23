using CAFU.Core;
using CAFU.Scene.Domain.Entity;
using Monry.CAFUSample.Application.Enumerate;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class GameResultNavigationUseCase : IUseCase, IInitializable
    {
        [Inject] private IGameResultNavigator GameResultNavigator { get; }
        [Inject] private IRequestEntity RequestEntity { get; }
        [Inject] private ISceneStateEntity SceneStateEntity { get; }

        void IInitializable.Initialize()
        {
            GameResultNavigator.OnNavigateToReplayAsObservable().Subscribe(_ => Replay());
            GameResultNavigator.OnNavigateToFinishAsObservable().Subscribe(_ => NavigateToTitle());
        }

        private void Replay()
        {
            SceneStateEntity
                .DidUnloadAsObservable(SceneName.SampleGame.ToString())
                .Take(1)
                .Subscribe(_ => RequestEntity.RequestLoad(SceneName.SampleGame.ToString()));
            RequestEntity.RequestUnload(SceneName.SampleGameResult.ToString());
        }

        private void NavigateToTitle()
        {
            RequestEntity.RequestLoad(SceneName.SampleTitle.ToString());
            RequestEntity.RequestUnload(SceneName.SampleGameResult.ToString());
        }
    }
}