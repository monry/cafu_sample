using Monry.CAFUSample.Domain.UseCase;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class GamePresenter :
        IGameScoreRenderable
    {
        [Inject] private IScoreRenderer ScoreRenderer { get; }

        public void RenderScore(int score)
        {
            ScoreRenderer.Render(score);
        }
    }
}