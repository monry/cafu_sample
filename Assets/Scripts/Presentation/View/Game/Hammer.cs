using System;
using ExtraUniRx;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.Game
{
    public class Hammer : MonoBehaviour, IAnimatorView, IHammer
    {
        private Animator animator;
        public Animator Animator => animator ? animator : animator = GetComponent<Animator>();

        private ITenseSubject<int> AttackSubject { get; set; }

        private int MoleIndex { get; set; }

        public void Attack()
        {
            AttackSubject.Did(MoleIndex);
        }

        [Inject]
        private void Initialize(int moleIndex, ITenseSubject<int> attackSubject, Transform moleTransform)
        {
            transform.SetParent(moleTransform);
            transform.localPosition = new Vector3(1.65f, 1.15f, 0.0f);
            AttackSubject = attackSubject;
            MoleIndex = moleIndex;
        }

        private void Start()
        {
            Animator.SetTrigger(Constant.Animator.TriggerName.Attack);
            Animator
                .OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Attack)
                .Delay(TimeSpan.FromSeconds(0.25f))
                .Subscribe(_ => Destroy(gameObject));
        }
    }
}