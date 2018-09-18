using System;
using CAFU.Core;
using CAFU.Scene.Domain.Entity;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Application.Enumerate;
using Monry.CAFUSample.Domain.Entity;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameStateUseCase : IUseCase
    {
    }

    public class GameStateUseCase : IGameStateUseCase, IInitializable
    {
        [Inject] private IScoreEntity ScoreEntity { get; }

        [Inject] private IRequestEntity RequestEntity { get; }

        [Inject] private IGameStateEntity GameStateEntity { get; }

        [Inject] private IGameScoreRenderable GameScoreRenderable { get; }

        private IDisposable GameTimerSubscription { get; set; }

        void IInitializable.Initialize()
        {
            ScoreEntity
                .Current
                .Subscribe(GameScoreRenderable.RenderScore);
            GameStateEntity
                .RemainingTime
                .Where(x => x < 0.0f)
                .First()
                .Subscribe(_ => StopGame());
            GameStateEntity.WillStartSubject.Subscribe(_ => StartGame());
            GameStateEntity.WillStopSubject.Subscribe(_ => StopGame());
            GameStateEntity.WillPauseSubject.Subscribe(_ => PauseGame());
            GameStateEntity.WillResumeSubject.Subscribe(_ => ResumeGame());
            GameStateEntity.WillFinishSubject.Subscribe(_ => FinishGame());
            GameStateEntity.WillAttackSubject.Subscribe(_ => ScoreEntity.Increment());

            Observable
                .Timer(TimeSpan.FromSeconds(1.0))
                .AsUnitObservable()
                .Subscribe(GameStateEntity.WillStartSubject.OnNext);
        }

        private void StartGame()
        {
            GameStateEntity.RemainingTime.Value = Constant.RemainingTime;
            GameTimerSubscription = Observable
                .EveryUpdate()
                .Subscribe(_ => GameStateEntity.RemainingTime.Value -= Time.deltaTime);
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

            // 終了帯とか出すならココを修正する
            GameStateEntity.WillFinishSubject.OnNext(Unit.Default);
        }

        private void PauseGame()
        {
            GameTimerSubscription?.Dispose();
        }

        private void FinishGame()
        {
            RequestEntity.RequestLoad(SceneName.SampleGameResult.ToString());
        }
    }
}