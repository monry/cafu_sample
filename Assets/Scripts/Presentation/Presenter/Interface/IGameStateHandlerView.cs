using System;
using CAFU.Core.Presentation.View;
using UniRx;

namespace Presentation.Presenter.Interface
{
    public interface IGameStateHandlerView : IView
    {
    }

    public interface IGameStateStartHandlerView : IGameStateHandlerView
    {
        IObservable<Unit> OnGameStartAsObservable();
    }

    public interface IGameStateStopHandlerView : IGameStateHandlerView
    {
        IObservable<Unit> OnGameStopAsObservable();
    }

    public interface IGameStateResumeHandlerView : IGameStateHandlerView
    {
        IObservable<Unit> OnGameResumeAsObservable();
    }

    public interface IGameStatePauseHandlerView : IGameStateHandlerView
    {
        IObservable<Unit> OnGamePauseAsObservable();
    }
}