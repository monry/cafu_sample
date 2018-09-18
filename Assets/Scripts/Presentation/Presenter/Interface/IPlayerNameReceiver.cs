using System;
using CAFU.Core;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IPlayerNameReceiver : IView
    {
        IObservable<string> OnReceiveAsObservable();
    }
}