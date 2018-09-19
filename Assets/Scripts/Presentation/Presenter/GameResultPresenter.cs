using System;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Structure.Presentation;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class GameResultPresenter : IGameResultHandler, IGameResultNavigator, IRankingHandler
    {
        [Inject] private IScoreRenderer ScoreRenderer { get; }
        [Inject] private IPlayerNameRenderer PlayerNameRenderer { get; }
        [Inject] private IPlayedAtRenderer PlayedAtRenderer { get; }
        [Inject] private IPlayerNameReceiver PlayerNameReceiver { get; }
        [Inject] private IRankingSaveTrigger TriggerRankingSave { get; }
        [Inject] private IRankingLoadTrigger TriggerRankingLoad { get; }
        [Inject(Id = Constant.InjectId.ButtonReplay)] private IButtonTrigger TriggerReplay { get; }
        [Inject(Id = Constant.InjectId.ButtonFinish)] private IButtonTrigger TriggerFinish { get; }

        public void RenderResult(IResult result)
        {
            ScoreRenderer.Render(result.Score);
            PlayerNameRenderer.Render(result.PlayerName);
            PlayedAtRenderer.Render(result.PlayedAt);
        }

        public IObservable<string> UpdatePlayerNameAsObservable()
        {
            return PlayerNameReceiver.OnReceiveAsObservable();
        }

        public IObservable<Unit> LoadAsObservable()
        {
            return TriggerRankingLoad.LoadTriggerAsObservable();
        }

        public IObservable<Unit> SaveAsObservable()
        {
            return TriggerRankingSave.SaveRankingAsObservable();
        }

        public IObservable<Unit> OnNavigateToReplayAsObservable()
        {
            return TriggerReplay.OnTriggerAsObservable();
        }

        public IObservable<Unit> OnNavigateToFinishAsObservable()
        {
            return TriggerFinish.OnTriggerAsObservable();
        }
    }
}