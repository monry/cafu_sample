using CAFU.Core;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IScoreView : IView
    {
        void Render(int score);
    }
}