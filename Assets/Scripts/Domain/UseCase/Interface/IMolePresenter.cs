using CAFU.Core;
using Monry.CAFUSample.Domain.Structure;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMolePresenter : IPresenter
    {
        void Instantiate(int index, IMole mole);
    }
}