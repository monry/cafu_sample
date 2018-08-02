using System;
using UniRx;
using IPresenter = CAFU.Core.Presentation.Presenter.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameStateHandlerPresenter : IPresenter
    {
        IObservable<Unit> OnStartAsObservable();
        IObservable<Unit> OnStopAsObservable();
        IObservable<Unit> OnResumeAsObservable();
        IObservable<Unit> OnPauseAsObservable();
    }
}