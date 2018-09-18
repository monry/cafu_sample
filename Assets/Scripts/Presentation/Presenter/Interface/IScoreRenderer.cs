using CAFU.Core;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IScoreRenderer : IView
    {
        void Render(int score);
    }
}