using System;
using ExtraUniRx;
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

        [Inject]
        private void Initialize(int index, IMole mole)
        {
            mole.ShowSubject.WhenDo().Subscribe(_ => Animator.SetTrigger(Constant.Animator.TriggerName.Show));
            mole.HideSubject.WhenDo().Subscribe(_ => Animator.SetTrigger(Constant.Animator.TriggerName.Hide));
            mole.FeintSubject.WhenDo().Subscribe(_ => Animator.SetTrigger(Constant.Animator.TriggerName.Feint));
            mole.HitSubject.WhenDo().Subscribe(_ => Animator.SetTrigger(Constant.Animator.TriggerName.Hit));
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Show).Subscribe(_ => mole.ShowSubject.Will());
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hide).Subscribe(_ => mole.HideSubject.Will());
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Feint).Subscribe(_ => mole.FeintSubject.Will());
            Animator.OnDispatchBeginAsObservable(Constant.Animator.AnimationStateName.Hit).Subscribe(_ => mole.HitSubject.Will());
            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Show).Subscribe(_ => mole.ShowSubject.Did());
            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hide).Subscribe(_ => mole.HideSubject.Did());
            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Feint).Subscribe(_ => mole.FeintSubject.Did());
            Animator.OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hit).Subscribe(_ => mole.HitSubject.Did());

            mole.ActivateSubject.Subscribe(_ => Collider2D.enabled = true);
            mole.DeactivateSubject.Subscribe(_ => Collider2D.enabled = false);

            this.OnPointerDownAsObservable().Subscribe(_ => mole.AttackSubject.Do(index));
            transform.localPosition = new Vector3(Random.Range(-8.0f, 8.0f), Random.Range(-4.5f, 4.5f), 0.0f);
        }

        public Transform GetTransform()
        {
            return transform;
        }
    }
}