using System;
using UniRx;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IMoleView : IActivationHandlableView
    {
        void Show();
        void Hide();
        void Feint();
        void Hit();
        bool CanAttack();
        IObservable<Unit> AttackAsObservable();
        IObservable<Unit> WillShowAsObservable();
        IObservable<Unit> WillHideAsObservable();
        IObservable<Unit> WillFeintAsObservable();
        IObservable<Unit> WillHitAsObservable();
        IObservable<Unit> DidShowAsObservable();
        IObservable<Unit> DidHideAsObservable();
        IObservable<Unit> DidFeintAsObservable();
        IObservable<Unit> DidHitAsObservable();
    }
}