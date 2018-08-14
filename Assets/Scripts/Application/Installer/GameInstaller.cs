using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.Presenter.Interface;
using Monry.CAFUSample.Presentation.View.Game;
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

        public override void InstallBindings()
        {
            // Entities
            Container.BindFactory<int, IMoleEntity, MoleEntity.Factory>().To<MoleEntity>();
            Container.Bind<IGameStateEntity>().To<GameStateEntity>().AsCached();

            // UseCases
            Container.BindInterfacesAndSelfTo<StageUseCase>().AsCached();
            Container.BindInterfacesAndSelfTo<GameStateUseCase>().AsCached();
            Container.BindFactory<IMoleEntity, IMoleUseCase, MoleUseCase.Factory>().To<MoleUseCase>();

            // Presenters
            Container.BindInterfacesAndSelfTo<GamePresenter>().AsCached();
            Container.BindFactory<IMoleEntity, IMolePresenter, MolePresenter.Factory>().To<MolePresenter>();

            // Views
            Container.BindInterfacesAndSelfTo<Controller>().FromComponentOnRoot().AsCached();
            Container.Bind<IScoreView>().To<Score>().FromComponentInHierarchy().AsCached();
//            Container.BindFactory<IMoleEntity, Mole, Mole.Factory>().FromComponentInNewPrefab(MolePrefab).UnderTransform(MoleParent);
            Container.BindFactory<IMoleEntity, Mole, PlaceholderFactory<IMoleEntity, Mole>>().FromComponentInNewPrefab(MolePrefab).UnderTransform(MoleParent);
        }
    }
}