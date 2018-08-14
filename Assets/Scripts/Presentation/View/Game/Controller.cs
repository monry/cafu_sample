using System;
using Presentation.Presenter.Interface;
using UniRx;
using UnityEngine;

namespace Monry.CAFUSample.Presentation.View.Game
{
    public class Controller : MonoBehaviour, IGameStateStartHandlerView
    {
        private Subject<Unit> StartTriggerSubject { get; } = new Subject<Unit>();

        private void Start()
        {
            Debug.Log("Controller.Start()");
            Observable
                .Timer(TimeSpan.FromSeconds(3.0))
                .AsUnitObservable()
                .Subscribe(StartTriggerSubject);
        }

        public IObservable<Unit> OnGameStartAsObservable()
        {
            return StartTriggerSubject;
        }
    }
}