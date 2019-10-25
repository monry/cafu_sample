using System;
using CAFUSample.Application.ValueObject.Master;
using UniRx;

namespace CAFUSample.Application.ValueObject.Transaction
{
    public class MoleStatus
    {
        private IReactiveProperty<MoleState> MoleStateReactiveProperty { get; } = new ReactiveProperty<MoleState>(MoleState.Hidden);

        public MoleState MoleState
        {
            get => MoleStateReactiveProperty.Value;
            set => MoleStateReactiveProperty.Value = value;
        }

        public IObservable<MoleState> OnStateChangedAsObservable() => MoleStateReactiveProperty;
    }
}