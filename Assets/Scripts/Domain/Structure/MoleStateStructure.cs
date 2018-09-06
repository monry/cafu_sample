using System;
using CAFU.Core;
using UniRx;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IMoleStateStructure : IStructure
    {
        Action Show { get; }
        Action Hide { get; }
        Action Feint { get; }
        Action Hit { get; }
        IObservable<Unit> WillShowObservable { get; }
        IObservable<Unit> WillHideObservable { get; }
        IObservable<Unit> WillFeintObservable { get; }
        IObservable<Unit> WillHitObservable { get; }
        IObservable<Unit> DidShowObservable { get; }
        IObservable<Unit> DidHideObservable { get; }
        IObservable<Unit> DidFeintObservable { get; }
        IObservable<Unit> DidHitObservable { get; }
    }

    public struct MoleStateStructure : IMoleStateStructure
    {
        public Action Show { get; set; }
        public Action Hide { get; set; }
        public Action Feint { get; set; }
        public Action Hit { get; set; }
        public IObservable<Unit> WillShowObservable { get; set; }
        public IObservable<Unit> WillHideObservable { get; set; }
        public IObservable<Unit> WillFeintObservable { get; set; }
        public IObservable<Unit> WillHitObservable { get; set; }
        public IObservable<Unit> DidShowObservable { get; set; }
        public IObservable<Unit> DidHideObservable { get; set; }
        public IObservable<Unit> DidFeintObservable { get; set; }
        public IObservable<Unit> DidHitObservable { get; set; }
    }
}