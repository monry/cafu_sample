using Monry.CAFUSample.UseCase;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.View.Game;
using Zenject;

namespace Monry.CAFUSample.Presenter
{
    public class MolePresenter : IMolePresenter
    {
        [Inject] private PlaceholderFactory<IMoleEntity, Mole> MoleViewFactory { get; }

        [Inject]
        private void Initialize(IMoleEntity moleEntity)
        {
            MoleViewFactory.Create(moleEntity);
        }
    }
}