using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.View.Ranking;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Scene
{
    public class RankingInstaller : MonoInstaller<RankingInstaller>
    {
        [SerializeField] private Transform rankingParent;
        private Transform RankingParent => rankingParent;

        [SerializeField] private Result resultPrefab;
        private Result ResultPrefab => resultPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<RankingNavigationUseCase>().AsCached();

            Container.BindInterfacesTo<ResultListPresenter>().AsCached();

            Container
                .BindIFactory<IResultRenderer>()
                .To<Result>()
                .FromComponentInNewPrefab(ResultPrefab)
                .UnderTransform(RankingParent);
        }
    }
}