using System.Collections.Generic;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.Translator;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Domain
{
    [CreateAssetMenu(fileName = "RankingInstaller", menuName = "Installers/RankingInstaller")]
    public class RankingInstaller : ScriptableObjectInstaller<RankingInstaller>
    {
        public override void InstallBindings()
        {
            // Structures
            Container.BindIFactory<int, IPresentationResult, IRanking>().To<Ranking>();
            Container.BindIFactory<IEnumerable<IRanking>, IRankingList>().To<RankingList>();

            // Translators
            Container.BindInterfacesTo<RankingTranslator>().AsCached();
        }
    }
}