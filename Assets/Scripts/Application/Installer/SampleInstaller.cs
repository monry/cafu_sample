using UniFlow;
using Zenject;

namespace CAFUSample.Application.Installer
{
    public class SampleInstaller : MonoInstaller<SampleInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInstance("Sample").WithId(InjectId.SceneNamePrefix);
        }
    }
}