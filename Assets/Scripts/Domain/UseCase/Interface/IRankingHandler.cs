using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IRankingHandler : IPresenter
    {
        IObservable<Unit> LoadAsObservable();
        IObservable<Unit> SaveAsObservable();
    }
}