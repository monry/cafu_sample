using System;
using Presentation.Presenter.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.Game
{
    public class Controller : MonoBehaviour, IGameStateStartHandlerView
    {
        [Inject] private DiContainer Container { get; }

        private Subject<Unit> StartTriggerSubject { get; } = new Subject<Unit>();

        private void Start()
        {
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