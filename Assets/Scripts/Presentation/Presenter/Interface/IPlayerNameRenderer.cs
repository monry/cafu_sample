using CAFU.Core;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IPlayerNameRenderer : IView
    {
        void Render(string playerName);
    }
}