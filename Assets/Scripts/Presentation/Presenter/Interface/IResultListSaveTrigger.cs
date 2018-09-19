using System;
using UniRx;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IResultListSaveTrigger
    {
        IObservable<Unit> SaveResultListAsObservable();
    }
}