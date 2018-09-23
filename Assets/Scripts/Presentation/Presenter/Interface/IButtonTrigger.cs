using System;
using CAFU.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IButtonTrigger : IView
    {
    }

    public static class ButtonTriggerExtensions
    {
        public static IObservable<Unit> OnTriggerAsObservable(this IButtonTrigger self)
        {
            var component = self as Component;
            if (component == null)
            {
                throw new InvalidCastException($"`{self.GetType().FullName}' does not seems to be UnityEngine.Component.");
            }

            return component.GetComponent<Button>().OnClickAsObservable();
        }
    }
}