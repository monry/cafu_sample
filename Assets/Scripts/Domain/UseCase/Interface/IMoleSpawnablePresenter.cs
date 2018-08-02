using CAFU.Core.Presentation.Presenter;
using Monry.CAFUSample.Application;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleSpawnablePresenter : IPresenter
    {
        void SpawnMoles(int amount = Constant.MoleAmount);
    }
}