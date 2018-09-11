using Monry.CAFUSample.Domain.Entity;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Entity
{
    [CreateAssetMenu(fileName = "ScoreInstaller", menuName = "Installers/Entity/ScoreInstaller")]
    public class ScoreInstaller : ScriptableObjectInstaller<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ScoreEntity>().AsCached();
        }
    }
}