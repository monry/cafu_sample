using CAFU.Core;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IActivationHandlableView : IView
    {
        void Activate();
        void Deactivate();
    }
}