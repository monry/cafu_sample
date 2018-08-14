using CAFU.Core.Presentation.Presenter;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleManagePresenter : IPresenter
    {
        int MoleCount { get; }
    }
}