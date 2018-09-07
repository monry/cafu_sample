using System;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class GameController : MonoBehaviour,
        IGameStateStartHandlerView
    {
        [Inject] private IGameStateEntity GameStateEntity { get; }

        private void Start()
        {
            Observable
                .Timer(TimeSpan.FromSeconds(3.0))
                .AsUnitObservable()
                .Subscribe(GameStateEntity.WillStartSubject);
        }
    }
}