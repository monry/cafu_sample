using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CAFU.Scene.Application.Installer;
using CAFU.Scene.Domain.Structure;
using CAFU.Scene.Domain.UseCase;
using Monry.CAFUSample.Application.Controller;
using Monry.CAFUSample.Domain.Structure;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Monry.CAFUSample.Application.Installer.Scene
{
    public class SystemInstaller : MonoInstaller<SystemInstaller>
    {
        [SerializeField] private SceneStrategyStructureList sceneStrategyStructureList;

        private ISceneStrategyStructureList SceneStrategyStructureList => sceneStrategyStructureList;

        public override void InstallBindings()
        {
            // シーン読み込みに関する処理群を Install
            //   Generics ナシの SceneInstall の場合 SimpleLoaderUseCase が Bind される
            //   PreLoad/PostUnload の設定を流し込みたいので StrategicLoaderUseCase を用いる
            SceneInstaller<StrategicLoaderUseCase>.Install(Container);
            // シーン名補完 delegate を Bind
            //   InjectOptional な項目として定義しているので、なくても良い
            //   ごっこランド的にはパビリオン名を Prefix にする必要があるので必須
            Container
                .Bind<Func<string, string>>()
                .WithId(CAFU.Scene.Application.Constant.InjectId.SceneNameCompleter)
                .FromInstance(sceneName => $"Sample_{sceneName}");
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
                        // 渡すべき文字列としては CAFU Scene 的な意味でのシーン名なので Prefix を除去
                        // ごっこランド的には必要だが、普通に開発する上ではこの行は不要
                        .Select(x => Regex.Replace(x, "^Sample_", string.Empty))
                );
            // シーン読み込み戦略データを Bind
            //   PreLoad/PostUnload の設定を仕込む
            Container
                .Bind<IReadOnlyDictionary<string, ISceneStrategyStructure>>()
                .WithId(CAFU.Scene.Application.Constant.InjectId.UseCase.SceneStrategyMap)
                .FromInstance(SceneStrategyStructureList.AsDictionary());

            // Controllers
            Container.BindInterfacesTo<SystemController>().FromComponentOnRoot().AsCached();
        }
    }
}