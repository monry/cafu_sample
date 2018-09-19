using System;
using System.IO;
using CAFU.Data.Data.DataStore;
using CAFU.Data.Data.Repository;
using CAFU.Data.Data.UseCase;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Translator;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Domain
{
    [CreateAssetMenu(fileName = "RankingInstaller", menuName = "Installers/RankingInstaller")]
    public class RankingInstaller : ScriptableObjectInstaller<RankingInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AsyncSubject<IResultEntity>>().FromInstance(new AsyncSubject<IResultEntity>()).AsCached();
            Container.Bind<AsyncSubject<IRankingEntity>>().FromInstance(new AsyncSubject<IRankingEntity>()).AsCached();
            Container.BindIFactory<IRankingEntity>().To<RankingEntity>();

            Container.BindInterfacesTo<RankingUseCase>().AsCached();

            Container.Bind<IAsyncRWHandler>().To<AsyncRWRepository>().AsCached();

            Container.BindInterfacesTo<AsyncLocalStorageDataStore>().AsCached();

            Container.BindInterfacesTo<RankingTranslator>().AsCached();

            Container
                .BindInstance(
                    new UriBuilder
                    {
                        Scheme = "file",
                        Host = string.Empty,
                        Path = Path.Combine(UnityEngine.Application.persistentDataPath, Constant.RankingFilePath),
                    }.Uri
                )
                .WithId(Constant.InjectId.RankingFileUri)
                .AsSingle();
        }
    }
}