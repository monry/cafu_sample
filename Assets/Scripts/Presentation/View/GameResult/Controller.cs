using System;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.GameResult
{
    public class Controller : MonoBehaviour, IInitializable, IResultListLoadTrigger
    {
        private ISubject<Unit> InitializeSubject { get; } = new Subject<Unit>();

        IObservable<Unit> IResultListLoadTrigger.LoadResultListAsObservable()
        {
            return InitializeSubject;
        }

        void IInitializable.Initialize()
        {
            InitializeSubject.OnNext(Unit.Default);
        }
    }
}