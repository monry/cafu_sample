using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.View.Title;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class TitleInstaller : MonoInstaller<TitleInstaller>
    {
        [SerializeField] private ButtonStart buttonStart;
        [SerializeField] private ButtonRanking buttonRanking;
        private ButtonStart ButtonStart => buttonStart;
        private ButtonRanking ButtonRanking => buttonRanking;

        public override void InstallBindings()
        {
            // UseCases
            Container.BindInterfacesTo<TitleNavigationUseCase>().AsCached();

            // Presenters
            Container.BindInterfacesTo<TitlePresenter>().AsCached();

            // Views
            Container.Bind<ITrigger>().WithId(Constant.InjectId.ButtonStart).FromInstance(ButtonStart).AsCached();
            Container.Bind<ITrigger>().WithId(Constant.InjectId.ButtonRanking).FromInstance(ButtonRanking).AsCached();
        }
    }
}