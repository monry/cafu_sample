using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.UseCase
{
    public interface IMolePresenter : IPresenter
    {
        void Instantiate(int index);

        void Show(int index);
        void Hide(int index);
        void Feint(int index);
        void Hit(int index);
        bool CanAttack(int index);

        void Activate(int index);
        void Deactivate(int index);

        IObservable<Unit> AttackAsObservable(int index);

        IObservable<Unit> WillShowAsObservable(int index);
        IObservable<Unit> WillHideAsObservable(int index);
        IObservable<Unit> WillFeintAsObservable(int index);
        IObservable<Unit> WillHitAsObservable(int index);
        IObservable<Unit> DidShowAsObservable(int index);
        IObservable<Unit> DidHideAsObservable(int index);
        IObservable<Unit> DidFeintAsObservable(int index);
        IObservable<Unit> DidHitAsObservable(int index);
    }
}