using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.View.Game;
using Monry.CAFUSample.UseCase;
using Monry.CAFUSample.View.Game;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private Mole molePrefab;
        private Mole MolePrefab => molePrefab;

        [SerializeField] private Transform moleParent;
        private Transform MoleParent => moleParent;

        [SerializeField] private Controller controller;
        private Controller Controller => controller;

        [SerializeField] private Score score;
        private Score Score => score;

        public override void InstallBindings()
        {
            // Entities
            Container.Bind<IGameStateEntity>().To<GameStateEntity>().AsCached();
            // MoleEntity は Factory 経由で生成
            Container.BindFactory<int, IMoleEntity, PlaceholderFactory<int, IMoleEntity>>().To<MoleEntity>();

            // UseCases
            Container.BindInterfacesTo<StageUseCase>().AsCached();
            Container.BindInterfacesTo<GameStateUseCase>().AsCached();
            Container.BindInterfacesTo<MoleUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<GamePresenter>().AsCached();
            Container.BindInterfacesTo<MolePresenter>().AsCached();

            // Views
            Container.BindInterfacesTo<Controller>().FromInstance(Controller).AsCached();
            Container.BindInterfacesTo<Score>().FromInstance(Score).AsCached();
            Container.BindFactory<int, IMoleView, PlaceholderFactory<int, IMoleView>>().To<Mole>().FromComponentInNewPrefab(MolePrefab).UnderTransform(MoleParent);
        }
    }
}