using CAFU.Core;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameScoreRenderable : IPresenter
    {
        void RenderScore(int score);
    }
}