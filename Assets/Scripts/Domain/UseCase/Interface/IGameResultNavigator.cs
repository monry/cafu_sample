using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameResultNavigator : IPresenter
    {
        IObservable<Unit> OnNavigateToReplayAsObservable();
        IObservable<Unit> OnNavigateToFinishAsObservable();
    }
}