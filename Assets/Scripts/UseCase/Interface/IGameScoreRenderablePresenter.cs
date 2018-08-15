using CAFU.Core;

namespace Monry.CAFUSample.UseCase
{
    public interface IGameScoreRenderablePresenter : IPresenter
    {
        void RenderScore(int score);
    }
}