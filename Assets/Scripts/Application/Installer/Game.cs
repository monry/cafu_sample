using Monry.CAFUSample.Domain.Model;
using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.Presenter.Interface;
using Monry.CAFUSample.Presentation.View.Game;
using Presentation.Presenter.Interface;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class Game: MonoInstaller<Game>
    {
        [SerializeField] private Mole molePrefab;

        [SerializeField] private Transform moleParent;

        private void Awake()
        {
            Debug.Log("Installer.Game.Awake");
        }

        public override void Start()
        {
            base.Start();
            Debug.Log("Installer.Game.Start");
        }

        public override void InstallBindings()
        {
            Debug.Log("Installer.Game.InstallBindings");

            // Presenters
            Container.Bind<GamePresenter>().AsTransient();
            Container.Bind<IGameScoreRenderablePresenter>().To<GamePresenter>().FromResolve();
            Container.Bind<IGameFinishNotifyablePresenter>().To<GamePresenter>().FromResolve();
            Container.Bind<IMoleSpawnablePresenter>().To<GamePresenter>().FromResolve();
            Container.Bind<IGameStateHandlerPresenter>().To<GamePresenter>().FromResolve();

            // Views
            Container.Bind<IMoleView>().FromComponentInNewPrefab(molePrefab).UnderTransform(moleParent).AsTransient();
            Container.Bind<IScoreView>().FromComponentInHierarchy();
            Container.Bind<IGameStateStartHandlerView>().FromComponentInHierarchy();

            // Models
            Container.Bind<IGameStateModel>().To<GameStateModel>().AsTransient();

            // UseCases
            Container.Bind<MoleUseCase>().AsCached();
            Container.Bind<GameStateUseCase>().AsCached();
            Container.Bind<IInitializable>().To<MoleUseCase>().FromResolve();
            Container.Bind<IInitializable>().To<GameStateUseCase>().FromResolve();
        }
    }
}