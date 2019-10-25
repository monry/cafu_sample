using CAFUSample.Domain.Entity.Implement;
using CAFUSample.Domain.UseCase.Implement;
using CAFUSample.Presentation.Presenter.Implement;
using Zenject;

namespace CAFUSample.Application.Installer.Scene
{
    public class SampleGameInstaller : MonoInstaller<SampleGameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HoleEntity>().AsCached();

            Container.BindInterfacesTo<GameStageUseCase>().AsCached();

            Container.BindInterfacesTo<HolePresenter>().AsCached();
        }
    }
}