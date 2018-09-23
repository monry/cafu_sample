using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IResultListHandler : IPresenter
    {
        IObservable<Unit> LoadAsObservable();
        IObservable<Unit> SaveAsObservable();
    }
}