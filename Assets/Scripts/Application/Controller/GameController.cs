using System;
using CAFU.Scene.Domain.Entity;
using Monry.CAFUSample.Domain.Entity;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class GameController : MonoBehaviour, IInitializable
    {
        [Inject] private IGameStateEntity GameStateEntity { get; }
        [Inject] private ILoadRequestEntity LoadRequestEntity { get; }

        void IInitializable.Initialize()
        {
            Observable
                .Timer(TimeSpan.FromSeconds(3.0))
                .AsUnitObservable()
                .Subscribe(GameStateEntity.WillStartSubject);
            Observable.Timer(TimeSpan.FromSeconds(5.0)).Subscribe(_ => LoadRequestEntity.RequestLoad("GameResult"));
            Observable.Timer(TimeSpan.FromSeconds(15.0)).Subscribe(_ => LoadRequestEntity.RequestUnload("Game"));
//            GameStateEntity.WillStopSubject.Delay(TimeSpan.FromSeconds(3)).Subscribe(_ => LoadRequestEntity.RequestUnload("Game"));
        }
    }
}