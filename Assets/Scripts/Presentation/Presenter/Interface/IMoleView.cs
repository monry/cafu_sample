using CAFU.Core;
using Monry.CAFUSample.Domain.Structure;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IMoleView : IView
    {
        IMoleStateStructure GenerateStateStructure();
        IMoleActivationStructure GenerateActivationStructure();
        IMoleAttackStructure GenerateAttackStructure();
    }
}