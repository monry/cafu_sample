using CAFU.Core.Presentation.Presenter;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleSpawnablePresenter : IPresenter
    {
        void SpawnMoles(int amount = Constant.MoleAmount);

        void SpawnMole(IMoleEntity moleEntity);
    }
}