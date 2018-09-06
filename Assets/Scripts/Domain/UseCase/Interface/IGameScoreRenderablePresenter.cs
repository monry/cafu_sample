using CAFU.Core;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameScoreRenderablePresenter : IPresenter
    {
        void RenderScore(int score);
    }
}