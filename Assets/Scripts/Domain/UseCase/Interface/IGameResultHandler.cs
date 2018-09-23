using System;
using Monry.CAFUSample.Domain.Structure;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameResultHandler : IPresenter
    {
        void RenderResult(IPresentationResult presentationResult);
        IObservable<string> UpdatePlayerNameAsObservable();
        IObservable<Unit> SaveAsObservable();
    }
}