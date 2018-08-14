using System;
using UniRx;

namespace Monry.CAFUSample.Entity
{
    public interface IMoleEntity
    {
        int Index { get; }
        Action Show { get; set; }
        Action Hide { get; set; }
        Action Feint { get; set; }
        Action Hit { get; set; }
        Func<bool> IsActive { get; set; }
        ISubject<Unit> WillActiveSubject { get; }
        ISubject<Unit> WillInactiveSubject { get; }
        ISubject<Unit> DidActiveSubject { get; }
        ISubject<Unit> DidInactiveSubject { get; }
    }

    public class MoleEntity : IMoleEntity
    {
        public int Index { get; }
        public Action Show { get; set; }
        public Action Hide { get; set; }
        public Action Feint { get; set; }
        public Action Hit { get; set; }
        public Func<bool> IsActive { get; set; }
        public ISubject<Unit> WillActiveSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> WillInactiveSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> DidActiveSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> DidInactiveSubject { get; } = new Subject<Unit>();

        public MoleEntity(int index)
        {
            Index = index;
        }
    }
}