using System;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace Monry.CAFUSample.Presentation.View.Title
{
    public class ButtonStart : UIBehaviour, ITrigger
    {
        public IObservable<Unit> OnTriggerAsObservable()
        {
            return this.OnPointerClickAsObservable().AsUnitObservable();
        }
    }
}