using Monry.CAFUSample.UseCase;
using Monry.CAFUSample.Presenter.Interface;
using Zenject;

namespace Monry.CAFUSample.Presenter
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