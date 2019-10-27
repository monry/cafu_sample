using System;
using UniRx;

namespace CAFUSample.Domain.Entity.Interface.UseCase
{
    public interface IMoleStateHandler
    {
        IObservable<Unit> OnAttackAsObservable();
        void Appear();
        void Disappear();
    }
}