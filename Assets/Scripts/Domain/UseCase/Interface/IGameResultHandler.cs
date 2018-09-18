using System;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.Structure.Presentation;
using UniRx;
using IPresenter = CAFU.Core.IPresenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameResultHandler : IPresenter
    {
        void RenderResult(IResult result);
        IObservable<string> UpdatePlayerNameAsObservable();
        IObservable<Unit> SaveAsObservable();
    }
}