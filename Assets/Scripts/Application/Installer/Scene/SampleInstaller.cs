using CAFUSample.Application.ValueObject.Master;
using UniFlow;
using UnityEngine;
using Zenject;

namespace CAFUSample.Application.Installer.Scene
{
    public class SampleInstaller : MonoInstaller<SampleInstaller>
    {
        [SerializeField] private GameSetting gameSetting = default;
        private GameSetting GameSetting => gameSetting;

        public override void InstallBindings()
        {
            Container.BindInstance(Constants.SceneNamePrefix).WithId(InjectId.SceneNamePrefix).AsCached();
            Container.BindInstance(GameSetting).AsCached();
        }
    }
}