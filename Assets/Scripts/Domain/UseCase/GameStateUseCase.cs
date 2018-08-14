using System;
using CAFU.Core.Domain.UseCase;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class GameStateUseCase : IUseCase, IInitializable
    {
        [Inject] private IGameStateEntity GameStateModel { get; }

        [Inject] private IGameScoreRenderablePresenter GameScoreRenderablePresenter { get; }

        [Inject] private IGameFinishNotifyablePresenter GameFinishNotifyablePresenter { get; }

        [Inject] private IGameStateHandlerPresenter GameStateHandlerPresenter { get; }

        private IDisposable GameTimerSubscription { get; set; }

        void IInitializable.Initialize()
        {
            Debug.Log("GameStateUseCase.Initialize()");
            GameStateModel
                .Score
                .Subscribe(GameScoreRenderablePresenter.RenderScore);
            GameStateModel
                .RemainingTime
                .Where(x => x < 0.0f)
                .First()
                .Subscribe(_ => StopGame());

            GameStateHandlerPresenter.OnStartAsObservable().Subscribe(_ => StartGame());
            GameStateHandlerPresenter.OnStopAsObservable().Subscribe(_ => StopGame());
            GameStateHandlerPresenter.OnResumeAsObservable().Subscribe(_ => ResumeGame());
            GameStateHandlerPresenter.OnPauseAsObservable().Subscribe(_ => PauseGame());
        }

        public GameStateUseCase()
        {
            Debug.Log("GameStateUseCase.ctor()");
        }

        public void ResetScore()
        {
            GameStateModel.Score.Value = 0;
        }

        private void StartGame()
        {
            GameStateModel.RemainingTime.Value = Constant.RemainingTime;
            GameTimerSubscription = Observable
                .EveryUpdate()
                .Subscribe(_ => GameStateModel.RemainingTime.Value -= Time.deltaTime);

            Debug.Log("StartGame");
        }

        private void ResumeGame()
        {
            GameTimerSubscription = Observable
                .EveryUpdate()
                .Subscribe(_ => GameStateModel.RemainingTime.Value -= Time.deltaTime);
        }

        private void StopGame()
        {
            GameTimerSubscription?.Dispose();
            GameStateModel.RemainingTime.Value = 0.0f;

            GameFinishNotifyablePresenter.OnGameFinished();
        }

        private void PauseGame()
        {
            GameTimerSubscription?.Dispose();
        }
    }
}