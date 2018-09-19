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
    [CreateAssetMenu(fileName = "ResultListInstaller", menuName = "Installers/ResultListInstaller")]
    public class ResultListInstaller : ScriptableObjectInstaller<ResultListInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AsyncSubject<IResultEntity>>().FromInstance(new AsyncSubject<IResultEntity>()).AsCached();
            Container.Bind<AsyncSubject<IResultListEntity>>().FromInstance(new AsyncSubject<IResultListEntity>()).AsCached();
            Container.BindIFactory<IResultListEntity>().To<ResultListEntity>();

            Container.BindInterfacesTo<RankingUseCase>().AsCached();

            Container.Bind<IAsyncRWHandler>().To<AsyncRWRepository>().AsCached();

            Container.BindInterfacesTo<AsyncLocalStorageDataStore>().AsCached();

            Container.BindInterfacesTo<ResultListTranslator>().AsCached();

            Container
                .BindInstance(
                    new UriBuilder
                    {
                        Scheme = "file",
                        Host = string.Empty,
                        Path = Path.Combine(UnityEngine.Application.persistentDataPath, Constant.ResultListFilePath),
                    }.Uri
                )
                .WithId(Constant.InjectId.RankingFileUri)
                .AsSingle();
        }
    }
}