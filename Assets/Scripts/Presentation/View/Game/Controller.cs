using System;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.Game
{
    public class Controller : MonoBehaviour,
        IGameStateStartHandlerView
    {
        [Inject] private IGameStateEntity GameStateEntity { get; }

        private void Start()
        {
            Debug.Log("Controller.Start()");
            Observable
                .Timer(TimeSpan.FromSeconds(3.0))
                .AsUnitObservable()
                .Subscribe(GameStateEntity.WillStartSubject);
        }
    }
}