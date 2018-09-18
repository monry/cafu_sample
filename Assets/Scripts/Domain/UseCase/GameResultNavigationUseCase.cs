using CAFU.Core;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class GameResultNavigationUseCase : IUseCase, IInitializable
    {
        [Inject] private IGameResultNavigator GameResultNavigator { get; }

        void IInitializable.Initialize()
        {
            GameResultNavigator.OnNavigateToReplayAsObservable().Subscribe();
            GameResultNavigator.OnNavigateToFinishAsObservable().Subscribe();
        }
    }
}