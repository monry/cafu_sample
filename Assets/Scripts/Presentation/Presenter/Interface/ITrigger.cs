using System;
using CAFU.Core;
using UniRx;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface ITrigger : IView
    {
        IObservable<Unit> OnTriggerAsObservable();
    }
}