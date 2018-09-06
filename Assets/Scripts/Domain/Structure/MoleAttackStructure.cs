using System;
using CAFU.Core;
using UniRx;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IMoleAttackStructure : IStructure
    {
        Func<bool> CanAttack { get; }
        IObservable<Unit> AttackObservable { get; }
    }

    public struct MoleAttackStructure : IMoleAttackStructure
    {
        public Func<bool> CanAttack { get; set; }
        public IObservable<Unit> AttackObservable { get; set; }
    }
}