using System.Collections.Generic;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.UseCase;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class MolePresenter : IMolePresenter
    {
        [Inject] private PlaceholderFactory<int, IMoleView> MoleViewFactory { get; }

        private List<IMoleView> MoleViewList { get; } = new List<IMoleView>();

        public void Instantiate(int index)
        {
            MoleViewList.Add(MoleViewFactory.Create(index));
        }

        public IMoleStateStructure GenerateStateStructure(int index)
        {
            return MoleViewList[index].GenerateStateStructure();
        }

        public IMoleActivationStructure GenerateActivationStructure(int index)
        {
            return MoleViewList[index].GenerateActivationStructure();
        }

        public IMoleAttackStructure GenerateAttackStructure(int index)
        {
            return MoleViewList[index].GenerateAttackStructure();
        }
    }
}