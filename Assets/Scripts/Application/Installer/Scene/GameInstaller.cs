using Monry.CAFUSample.Application.Controller;
using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.View.Game;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Scene
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private Mole molePrefab;
        private Mole MolePrefab => molePrefab;

        [SerializeField] private Transform moleParent;
        private Transform MoleParent => moleParent;

        [SerializeField] private Score score;
        private Score Score => score;

        public override void InstallBindings()
        {
            // Entities
            Container.Bind<IGameStateEntity>().To<GameStateEntity>().AsCached();
            // MoleEntity は Factory 経由で生成
            Container.BindIFactory<int, IMoleEntity>().To<MoleEntity>();

            // UseCases
            Container.BindInterfacesTo<GameStateUseCase>().AsCached();
            Container.BindInterfacesTo<MoleUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<GamePresenter>().AsCached();
            Container.BindInterfacesTo<MolePresenter>().AsCached();

            // Views
            Container.BindInterfacesTo<Score>().FromInstance(Score).AsCached();
            Container
                // IMoleView の Factory を登録
                .BindIFactory<int, IMoleView>()
                // Mole 型として
                .To<Mole>()
                // MolePrefab 内のコンポーネントを用いて
                .FromComponentInNewPrefab(MolePrefab)
                // MoleParent の配下に
                .UnderTransform(MoleParent);

            // Controllers
            // FromComponentOnRoot は、Installer が Attach されている GameObject から見た
            // Root GameObject から探す（っぽい）ので、 GameController は
            // Installer と同一 GameObject に Attach しています
            Container.BindInterfacesTo<GameController>().FromComponentOnRoot().AsCached();
        }
    }
}