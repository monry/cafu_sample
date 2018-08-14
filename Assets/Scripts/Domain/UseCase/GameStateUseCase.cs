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
        [Inject] private IGameStateEntity GameStateEntity { get; }

        [Inject] private IGameScoreRenderablePresenter GameScoreRenderablePresenter { get; }

        [Inject] private IGameFinishNotifyablePresenter GameFinishNotifyablePresenter { get; }

        [Inject] private IGameStateHandlerPresenter GameStateHandlerPresenter { get; }

        private IDisposable GameTimerSubscription { get; set; }

        void IInitializable.Initialize()
        {
            Debug.Log("GameStateUseCase.Initialize()");
            GameStateEntity
                .Score
                .Subscribe(GameScoreRenderablePresenter.RenderScore);
            GameStateEntity
                .RemainingTime
                .Where(x => x < 0.0f)
                .First()
                .Subscribe(_ => StopGame());
            GameStateEntity.WillStartSubject.Subscribe(_ => StartGame());
            GameStateEntity.WillStopSubject.Subscribe(_ => StopGame());
            GameStateEntity.WillPauseSubject.Subscribe(_ => PauseGame());
            GameStateEntity.WillResumeSubject.Subscribe(_ => ResumeGame());
        }

        public GameStateUseCase()
        {
            Debug.Log("GameStateUseCase.ctor()");
        }

        public void ResetScore()
        {
            GameStateEntity.Score.Value = 0;
        }

        private void StartGame()
        {
            GameStateEntity.RemainingTime.Value = Constant.RemainingTime;
            GameTimerSubscription = Observable
                .EveryUpdate()
                .Subscribe(_ => GameStateEntity.RemainingTime.Value -= Time.deltaTime);

            Debug.Log("StartGame");
        }

        private void ResumeGame()
        {
            GameTimerSubscription = Observable
                .EveryUpdate()
                .Subscribe(_ => GameStateEntity.RemainingTime.Value -= Time.deltaTime);
        }

        private void StopGame()
        {
            GameTimerSubscription?.Dispose();
            GameStateEntity.RemainingTime.Value = 0.0f;

            GameFinishNotifyablePresenter.OnGameFinished();
        }

        private void PauseGame()
        {
            GameTimerSubscription?.Dispose();
        }
    }
}