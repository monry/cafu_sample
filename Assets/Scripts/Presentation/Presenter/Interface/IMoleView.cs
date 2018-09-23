using CAFU.Core;
using Monry.CAFUSample.Domain.Structure;
using UnityEngine;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IMoleView : IView
    {
//        IMoleStateStructure GenerateStateStructure();
//        IMoleActivationStructure GenerateActivationStructure();
//        IMoleAttackStructure GenerateAttackStructure();
        Transform GetTransform();
    }
}