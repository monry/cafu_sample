using System;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityModule.AnimationEventDispatcher;
using Zenject;
using Random = UnityEngine.Random;

namespace Monry.CAFUSample.Presentation.View.Game
{
    // ToDo: 共通化する
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

        [Inject] private int Index { get; }

        protected override void Awake()
        {
            base.Awake();

            transform.localPosition = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.5f, 4.5f), 0.0f);
        }

        public void Show()
        {
            Animator.SetTrigger(Constant.Animator.TriggerName.Show);
        }

        public void Hide()
        {
            Animator.SetTrigger(Constant.Animator.TriggerName.Hide);
        }

        public void Feint()
        {
            Animator.SetTrigger(Constant.Animator.TriggerName.Feint);
        }

        public void Hit()
        {
            Animator.SetTrigger(Constant.Animator.TriggerName.Hit);
        }

        public bool CanAttack()
        {
            return Collider2D.enabled;
        }

        public IObservable<Unit> AttackAsObservable()
        {
            return this.OnPointerDownAsObservable().AsUnitObservable();
        }

        public IObservable<Unit> WillShowAsObservable()
        {
            return Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Show).AsUnitObservable();
        }

        public IObservable<Unit> WillHideAsObservable()
        {
            return Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hide).AsUnitObservable();
        }

        public IObservable<Unit> WillFeintAsObservable()
        {
            return Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Feint).AsUnitObservable();
        }

        public IObservable<Unit> WillHitAsObservable()
        {
            return Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hit).AsUnitObservable();
        }

        public IObservable<Unit> DidShowAsObservable()
        {
            return Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Show).AsUnitObservable();
        }

        public IObservable<Unit> DidHideAsObservable()
        {
            return Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hide).AsUnitObservable();
        }

        public IObservable<Unit> DidFeintAsObservable()
        {
            return Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Feint).AsUnitObservable();
        }

        public IObservable<Unit> DidHitAsObservable()
        {
            return Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hit).AsUnitObservable();
        }

        public void Activate()
        {
            Collider2D.enabled = true;
        }

        public void Deactivate()
        {
            Collider2D.enabled = false;
        }
    }
}