using System;
using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter.Interface;
using Presentation.Presenter.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class GamePresenter :
        IGameFinishNotifyablePresenter,
        IGameScoreRenderablePresenter,
        IGameStateHandlerPresenter
    {
        // XXX: ココ、Factory Pattern にできないか検討する
        [Inject] private DiContainer Container { get; }

        [Inject] private IScoreView ScoreView { get; }

        [Inject] private IGameStateStartHandlerView GameStateStartHandlerView { get; }

        public void RenderScore(int score)
        {
            ScoreView.Render(score);
        }

        public IObservable<Unit> OnStartAsObservable()
        {
            return GameStateStartHandlerView.OnGameStartAsObservable();
        }

        public IObservable<Unit> OnStopAsObservable()
        {
            return Observable.Empty<Unit>();
        }

        public IObservable<Unit> OnResumeAsObservable()
        {
            return Observable.Empty<Unit>();
        }

        public IObservable<Unit> OnPauseAsObservable()
        {
            return Observable.Empty<Unit>();
        }

        public void OnGameFinished()
        {
            Debug.Log("GameFinished!!!");
        }
    }
}