using CAFU.Scene.Application.Installer;
using Monry.CAFUSample.Presentation.View.System;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class SystemInstaller : MonoInstaller<SystemInstaller>
    {
        public override void InstallBindings()
        {
            SceneInstaller.Install(Container);

            Container.BindInterfacesTo<SystemController>().FromComponentOnRoot().AsCached();
        }
    }
}