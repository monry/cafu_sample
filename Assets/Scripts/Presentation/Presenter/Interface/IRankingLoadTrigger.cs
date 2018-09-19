using System;
using CAFU.Core;
using UniRx;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IRankingLoadTrigger : IView
    {
        IObservable<Unit> LoadTriggerAsObservable();
    }
}