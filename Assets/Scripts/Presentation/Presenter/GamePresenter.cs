using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter.Interface;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class GamePresenter :
        IGameScoreRenderablePresenter
    {
        [Inject] private IScoreView ScoreView { get; }

        public void RenderScore(int score)
        {
            ScoreView.Render(score);
        }
    }
}