using CAFU.Core.Presentation.View;

namespace Monry.CAFUSample.Presentation.Presenter.Interface
{
    public interface IScoreView : IView
    {
        void Render(int score);
    }
}