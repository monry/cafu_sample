using System;
using System.Collections.Generic;
using CAFU.Core;
using ExtraLinq;
using Monry.CAFUSample.Application;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Entity
{
    public interface IMoleEntity : IEntity
    {
        int Index { get; }
        Action Show { get; set; }
        Action Hide { get; set; }
        Action Feint { get; set; }
        Action Hit { get; set; }
        Func<bool> CanAttack { get; set; }
        ISubject<Unit> WillActiveSubject { get; }
        ISubject<Unit> WillInactiveSubject { get; }
        ISubject<Unit> DidActiveSubject { get; }
        ISubject<Unit> DidInactiveSubject { get; }
        void Start();
        void Finish();
    }

    public class MoleEntity : IMoleEntity, IInitializable
    {
        private static readonly Dictionary<string, Action<IMoleEntity>> NextActionMap = new Dictionary<string, Action<IMoleEntity>>
        {
            { Constant.Animator.AnimationStateName.Show, x => x.Show() },
            { Constant.Animator.AnimationStateName.Feint, x => x.Feint() },
        };

        public int Index { get; }
        public Action Show { get; set; }
        public Action Hide { get; set; }
        public Action Feint { get; set; }
        public Action Hit { get; set; }
        public Func<bool> CanAttack { get; set; }
        public ISubject<Unit> WillActiveSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> WillInactiveSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> DidActiveSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> DidInactiveSubject { get; } = new Subject<Unit>();

        public void Start()
        {
            DidInactiveSubject.OnNext(Unit.Default);
        }

        public void Finish()
        {
            WillActiveSubject.OnCompleted();
            WillInactiveSubject.OnCompleted();
            DidActiveSubject.OnCompleted();
            DidInactiveSubject.OnCompleted();
        }

        public MoleEntity(int index)
        {
            Index = index;
        }

        public void Initialize()
        {
            DidActiveSubject
                .Delay(TimeSpan.FromSeconds(Constant.MoleActiveDuration))
                .Where(_ => CanAttack?.Invoke() ?? false)
                .Subscribe(_ => Hide?.Invoke());
            DidInactiveSubject
                .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(UnityEngine.Random.Range(Constant.MoleInactiveDurationFrom, Constant.MoleInactiveDurationTo))))
                .Select(_ => NextActionMap.Random())
                .Subscribe(x => x.Value?.Invoke(this));
        }

    }
}