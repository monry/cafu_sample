using ExtraUniRx;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.Translator;
using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.View.Game;
using UnityEngine;
using Zenject;
using Mole = Monry.CAFUSample.Presentation.View.Game.Mole;

namespace Monry.CAFUSample.Application.Installer.Scene
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField] private Mole molePrefab;
        private Mole MolePrefab => molePrefab;
        [SerializeField] private Hammer hammerPrefab;
        private Hammer HammerPrefab => hammerPrefab;

        [SerializeField] private Transform moleParent;
        private Transform MoleParent => moleParent;

        [SerializeField] private Score score;
        private Score Score => score;

        public override void InstallBindings()
        {
            // Entities
            Container.Bind<IGameStateEntity>().To<GameStateEntity>().AsCached();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();
            // MoleEntity は Factory 経由で生成
            Container.BindIFactory<int, IMoleEntity>().To<MoleEntity>();

            // Structures
            Container.BindInterfacesTo<MoleTranslator>().AsCached();

            // UseCases
            Container.BindInterfacesTo<GameStateUseCase>().AsCached();
            Container.BindInterfacesTo<MoleUseCase>().AsCached();
            Container.BindInterfacesTo<HammerUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<GamePresenter>().AsCached();
            Container.BindInterfacesTo<MolePresenter>().AsCached();
            Container.BindInterfacesTo<HammerPresenter>().AsCached();

            // Views
            Container.BindInterfacesTo<Score>().FromInstance(Score).AsCached();
            Container
                // IMoleView の Factory を登録
                .BindIFactory<int, IMole, IMoleView>()
                // Mole 型として
                .To<Mole>()
                // MolePrefab 内のコンポーネントを用いて
                .FromComponentInNewPrefab(MolePrefab)
                // MoleParent の配下に
                .UnderTransform(MoleParent);
            Container
                .BindIFactory<int, ITenseSubject<int>, Transform, IHammer>()
                .To<Hammer>()
                .FromComponentInNewPrefab(HammerPrefab);
        }
    }
}