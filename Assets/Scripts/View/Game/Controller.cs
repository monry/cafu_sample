using System;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presenter.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.View.Game
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