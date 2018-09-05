using CAFU.Core;

namespace Monry.CAFUSample.Presentation.Presenter
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