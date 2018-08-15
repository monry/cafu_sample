using System;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presenter.Interface;
using Monry.CAFUSample.Presenter.Interfaces;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityModule.AnimationEventDispatcher;
using Zenject;
using Random = UnityEngine.Random;

namespace Monry.CAFUSample.View.Game
{
    public static class AnimatorExtensions
    {
        public static IObservable<AnimationEvent> OnDispatchBeginAsObservable(this Animator animator, string animationClipName)
        {
            return animator.GetComponent<GeneralDispatcher>().OnDispatchBeginAsObservable(animationClipName);
        }

        public static IObservable<AnimationEvent> OnDispatchEndAsObservable(this Animator animator, string animationClipName)
        {
            return animator.GetComponent<GeneralDispatcher>().OnDispatchEndAsObservable(animationClipName);
        }
    }

    public class Mole : UIBehaviour, IMoleView, IVisibilityAnimatorView
    {
        private Animator animator;
        public Animator Animator => animator ? animator : (animator = GetComponentInChildren<Animator>());

        // ReSharper disable once InconsistentNaming
        private Collider2D _collider2D;
        private Collider2D Collider2D => _collider2D ? _collider2D : (_collider2D = GetComponentInChildren<Collider2D>());

        [Inject] private IMoleEntity MoleEntity { get; }

        protected override void Awake()
        {
            base.Awake();

            transform.localPosition = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.5f, 4.5f), 0.0f);

            MoleEntity.Show = () => Animator.SetTrigger(Constant.Animator.TriggerName.Show);
            MoleEntity.Hide = () => Animator.SetTrigger(Constant.Animator.TriggerName.Hide);
            MoleEntity.Feint = () => Animator.SetTrigger(Constant.Animator.TriggerName.Feint);
            MoleEntity.Hit = () => Animator.SetTrigger(Constant.Animator.TriggerName.Hit);
            MoleEntity.IsActive = () => Collider2D.enabled;

            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Show).AsUnitObservable().Subscribe(MoleEntity.WillActiveSubject);
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Feint).AsUnitObservable().Subscribe(MoleEntity.WillInactiveSubject);
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hide).AsUnitObservable().Subscribe(MoleEntity.WillInactiveSubject);
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hit).AsUnitObservable().Subscribe(MoleEntity.WillInactiveSubject);

            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Show).AsUnitObservable().Subscribe(MoleEntity.DidActiveSubject);
            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hide).AsUnitObservable().Subscribe(MoleEntity.DidInactiveSubject);
            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Feint).AsUnitObservable().Subscribe(MoleEntity.DidInactiveSubject);
        }

        protected override void Start()
        {
            base.Start();
            MoleEntity.DidActiveSubject.Subscribe(_ => Collider2D.enabled = true);
            MoleEntity.WillInactiveSubject.Subscribe(_ => Collider2D.enabled = false);
            this.OnPointerDownAsObservable().AsUnitObservable().Subscribe(_ => MoleEntity.Hit());
        }
    }
}