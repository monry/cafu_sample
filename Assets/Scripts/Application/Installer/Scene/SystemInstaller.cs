using System.Collections.Generic;
using System.Linq;
using CAFU.Scene.Application.Installer;
using CAFU.Scene.Domain.Structure;
using CAFU.Scene.Domain.UseCase;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Presentation.View.System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Scene
{
    // FIXME: 汎用化する
    public class SystemInstaller : MonoInstaller<SystemInstaller>
    {
        [SerializeField] private SceneStrategyList sceneStrategyList;

        private ISceneStrategyList SceneStrategyList => sceneStrategyList;

        public override void InstallBindings()
        {
            // シーン読み込みに関する処理群を Install
            //   Generics ナシの SceneInstall の場合 SimpleLoaderUseCase が Bind される
            //   PreLoad/PostUnload の設定を流し込みたいので StrategicLoaderUseCase を用いる
            SceneInstaller<StrategicLoaderUseCase>.Install(Container);

            // ココは再帰的にやらないとダメかも
            Container.QueueForInject(SceneStrategyList);

            // 初期シーン一覧を Bind
            //   CAFU.Scene 的に必要
            Container
                .Bind<IEnumerable<string>>()
                .WithId(CAFU.Scene.Application.Constant.InjectId.InitialSceneNameList)
                .FromInstance(
                    Enumerable
                        .Range(0, SceneManager.sceneCount)
                        .Select(SceneManager.GetSceneAt)
                        .Select(x => x.name)
                );
            // シーン読み込み戦略データを Bind
            //   PreLoad/PostUnload の設定を仕込む
            Container
                .Bind<IDictionary<string, ISceneStrategy>>()
                .WithId(CAFU.Scene.Application.Constant.InjectId.UseCase.SceneStrategyMap)
                .FromInstance(SceneStrategyList.AsDictionary());

            // Controllers
            Container.BindInterfacesTo<Controller>().FromComponentOnRoot().AsCached();
        }
    }
}