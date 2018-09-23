using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IResultListClearable : IPresenter
    {
        IObservable<Unit> ClearAsObservable();
    }
}