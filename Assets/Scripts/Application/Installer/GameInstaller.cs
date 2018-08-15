using Monry.CAFUSample.UseCase;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presenter;
using Monry.CAFUSample.Presenter.Interface;
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

        public override void InstallBindings()
        {
            // Entities
            Container.BindFactory<int, IMoleEntity, PlaceholderFactory<int, IMoleEntity>>().To<MoleEntity>();
            Container.Bind<IGameStateEntity>().To<GameStateEntity>().AsCached();

            // UseCases
            Container.BindInterfacesAndSelfTo<StageUseCase>().AsCached();
            Container.BindInterfacesAndSelfTo<GameStateUseCase>().AsCached();
            Container.BindFactory<IMoleEntity, IMoleUseCase, PlaceholderFactory<IMoleEntity, IMoleUseCase>>().To<MoleUseCase>();

            // Presenters
            Container.BindInterfacesAndSelfTo<GamePresenter>().AsCached();
            Container.BindFactory<IMoleEntity, IMolePresenter, PlaceholderFactory<IMoleEntity, IMolePresenter>>().To<MolePresenter>();

            // Views
            Container.BindInterfacesAndSelfTo<Controller>().FromInstance(Controller).AsCached();
            Container.Bind<IScoreView>().To<Score>().FromComponentInHierarchy().AsCached();
            Container.BindFactory<IMoleEntity, Mole, PlaceholderFactory<IMoleEntity, Mole>>().FromComponentInNewPrefab(MolePrefab).UnderTransform(MoleParent);
        }
    }
}