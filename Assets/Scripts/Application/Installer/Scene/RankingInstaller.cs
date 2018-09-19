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

        [SerializeField] private ButtonBack buttonBack;
        private ButtonBack ButtonBack => buttonBack;

        public override void InstallBindings()
        {
            // UseCases
            Container.BindInterfacesTo<RankingNavigationUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<RankingPresenter>().AsCached();

            // Views
            Container.Bind<IButtonTrigger>().WithId(Constant.InjectId.ButtonBack).FromInstance(ButtonBack).AsCached();
            Container
                .BindIFactory<IResultRenderer>()
                .To<Result>()
                .FromComponentInNewPrefab(ResultPrefab)
                .UnderTransform(RankingParent);
        }
    }
}