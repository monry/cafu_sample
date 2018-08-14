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
    }

    public interface IGameStateStopHandlerView : IGameStateHandlerView
    {
    }

    public interface IGameStateResumeHandlerView : IGameStateHandlerView
    {
    }

    public interface IGameStatePauseHandlerView : IGameStateHandlerView
    {
    }
}