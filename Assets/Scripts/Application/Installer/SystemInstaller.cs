using CAFU.Scene.Application.Installer;
using Monry.CAFUSample.Application.Controller;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class SystemInstaller : MonoInstaller<SystemInstaller>
    {
        public override void InstallBindings()
        {
            SceneInstaller.Install(Container);

            // Controllers
            Container.BindInterfacesTo<SystemController>().FromComponentOnRoot().AsCached();
        }
    }
}