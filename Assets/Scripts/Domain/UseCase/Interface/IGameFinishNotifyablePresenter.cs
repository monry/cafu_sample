using System;
using UniRx;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IGameFinishNotifyablePresenter
    {
        void OnGameFinished();
    }
}