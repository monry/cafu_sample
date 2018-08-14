using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presentation.View.Game;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class MolePresenter : IMolePresenter
    {
//        [Inject] private Mole.Factory MoleViewFactory { get; }
        [Inject] private PlaceholderFactory<IMoleEntity, Mole> MoleViewFactory { get; }

        [Inject]
        private void Initialize(IMoleEntity moleEntity)
        {
            MoleViewFactory.Create(moleEntity);
        }

        public class Factory : PlaceholderFactory<IMoleEntity, IMolePresenter>
        {
        }
    }
}