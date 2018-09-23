using System;
using CAFU.Core;
using UniRx;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IResultListLoadTrigger : IView
    {
        IObservable<Unit> LoadResultListAsObservable();
    }
}