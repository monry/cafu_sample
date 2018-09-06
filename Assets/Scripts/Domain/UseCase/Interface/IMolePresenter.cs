using CAFU.Core;
using Monry.CAFUSample.Domain.Structure;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMolePresenter : IPresenter
    {
        void Instantiate(int index);

        IMoleStateStructure GenerateStateStructure(int index);
        IMoleActivationStructure GenerateActivationStructure(int index);
        IMoleAttackStructure GenerateAttackStructure(int index);
    }
}