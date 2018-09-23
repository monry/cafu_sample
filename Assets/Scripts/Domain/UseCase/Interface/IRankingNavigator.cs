using System;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IRankingNavigator : IPresenter
    {
        IObservable<Unit> OnNavigateToTitleAsObservable();
    }
}