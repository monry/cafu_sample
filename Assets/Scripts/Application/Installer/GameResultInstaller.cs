using Monry.CAFUSample.Application.Controller;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class GameResultInstaller : MonoInstaller<GameResultInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameResultController>().FromComponentOnRoot().AsCached();
        }
    }
}