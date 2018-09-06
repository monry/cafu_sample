using System;
using Monry.CAFUSample.Domain.Structure;
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

        public IMoleStateStructure GenerateStateStructure()
        {
            return new MoleStateStructure
            {
                Show = () => Animator.SetTrigger(Constant.Animator.TriggerName.Show),
                Hide = () => Animator.SetTrigger(Constant.Animator.TriggerName.Hide),
                Feint = () => Animator.SetTrigger(Constant.Animator.TriggerName.Feint),
                Hit = () => Animator.SetTrigger(Constant.Animator.TriggerName.Hit),
                WillShowObservable = Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Show).AsUnitObservable(),
                WillHideObservable = Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hide).AsUnitObservable(),
                WillFeintObservable = Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Feint).AsUnitObservable(),
                WillHitObservable = Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hit).AsUnitObservable(),
                DidShowObservable = Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Show).AsUnitObservable(),
                DidHideObservable = Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hide).AsUnitObservable(),
                DidFeintObservable = Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Feint).AsUnitObservable(),
                DidHitObservable = Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hit).AsUnitObservable(),
            };
        }

        public IMoleActivationStructure GenerateActivationStructure()
        {
            return new MoleActivationStructure
            {
                Activate = () => Collider2D.enabled = true,
                Deactivate = () => Collider2D.enabled = false,
            };
        }

        public IMoleAttackStructure GenerateAttackStructure()
        {
            return new MoleAttackStructure
            {
                CanAttack = () => Collider2D.enabled,
                AttackObservable = this.OnPointerDownAsObservable().AsUnitObservable(),
            };
        }
    }
}