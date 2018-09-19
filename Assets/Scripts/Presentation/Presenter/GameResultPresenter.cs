using System;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class GameResultPresenter : IGameResultHandler, IGameResultNavigator, IResultListHandler
    {
        [Inject] private IScoreRenderer ScoreRenderer { get; }
        [Inject] private IPlayerNameRenderer PlayerNameRenderer { get; }
        [Inject] private IPlayedAtRenderer PlayedAtRenderer { get; }
        [Inject] private IPlayerNameReceiver PlayerNameReceiver { get; }
        [Inject] private IResultListSaveTrigger TriggerResultListSave { get; }
        [Inject] private IResultListLoadTrigger TriggerResultListLoad { get; }
        [Inject(Id = Constant.InjectId.ButtonReplay)] private IButtonTrigger TriggerReplay { get; }
        [Inject(Id = Constant.InjectId.ButtonFinish)] private IButtonTrigger TriggerFinish { get; }

        public void RenderResult(IPresentationResult presentationResult)
        {
            ScoreRenderer.Render(presentationResult.Score);
            PlayerNameRenderer.Render(presentationResult.PlayerName);
            PlayedAtRenderer.Render(presentationResult.PlayedAt);
        }

        public IObservable<string> UpdatePlayerNameAsObservable()
        {
            return PlayerNameReceiver.OnReceiveAsObservable();
        }

        public IObservable<Unit> LoadAsObservable()
        {
            return TriggerResultListLoad.LoadResultListAsObservable();
        }

        public IObservable<Unit> SaveAsObservable()
        {
            return TriggerResultListSave.SaveResultListAsObservable();
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