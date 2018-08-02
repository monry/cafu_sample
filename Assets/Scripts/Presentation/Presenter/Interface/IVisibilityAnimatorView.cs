using System;
using Monry.CAFUSample.Application;
using UniRx;
using UnityModule.AnimationEventDispatcher;

namespace Monry.CAFUSample.Presentation.Presenter.Interfaces
{
    public interface IVisibilityAnimatorView : IAnimatorView
    {
    }

    public static class VisibilityAnimatorViewExtensions
    {
        public static void Show(this IVisibilityAnimatorView view)
        {
            view.Animator.SetTrigger(Constant.Animator.TriggerName.Show);
        }

        public static void Hide(this IVisibilityAnimatorView view)
        {
            view.Animator.SetTrigger(Constant.Animator.TriggerName.Hide);
        }

        public static IObservable<Unit> OnShowAsObservable(this IVisibilityAnimatorView view)
        {
            return view
                .Animator
                .GetComponent<GeneralDispatcher>()
                .OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Show)
                .AsUnitObservable();
        }

        public static IObservable<Unit> OnHideAsObservable(this IVisibilityAnimatorView view)
        {
            return view
                .Animator
                .GetComponent<GeneralDispatcher>()
                .OnDispatchEndAsObservable(Constant.Animator.AnimationStateName.Hide)
                .AsUnitObservable();
        }
    }
}