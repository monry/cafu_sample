using System;
using System.Collections.Generic;
using System.IO;
using CAFU.Data.Data.DataStore;
using CAFU.Data.Data.Repository;
using CAFU.Data.Data.UseCase;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.Translator;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Domain
{
    [CreateAssetMenu(fileName = "ResultInstaller", menuName = "Installers/ResultInstaller")]
    public class ResultInstaller : ScriptableObjectInstaller<ResultInstaller>
    {
        public override void InstallBindings()
        {
            // Entities
            Container.Bind<AsyncSubject<IResultEntity>>().FromInstance(new AsyncSubject<IResultEntity>()).AsCached();
            Container.Bind<AsyncSubject<IResultListEntity>>().FromInstance(new AsyncSubject<IResultListEntity>()).AsCached();
            Container.BindIFactory<int, string, DateTime, IResultEntity>().To<ResultEntity>();
            Container.BindIFactory<IEnumerable<IResultEntity>, IResultListEntity>().To<ResultListEntity>();

            // Structures
            Container.BindIFactory<int, string, DateTime, IPresentationResult>().To<PresentationResult>();
            Container.BindIFactory<int, string, string, IDataResult>().To<DataResult>();

            // UseCases
            Container.BindInterfacesTo<ResultUseCase>().AsCached();

            // Repositories
            Container.Bind<IAsyncRWHandler>().To<AsyncRWRepository>().AsCached();

            // DataStores
            Container.BindInterfacesTo<AsyncLocalStorageDataStore>().AsCached();

            // Translators
            Container.BindInterfacesTo<ResultTranslator>().AsCached();

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