using Monry.CAFUSample.Application.Enumerate;
using CAFU.Scene.Domain.Entity;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class SystemController : MonoBehaviour, IInitializable
    {
        [Inject] private ILoadRequestEntity LoadRequestEntity { get; }
        [Inject] private ISceneStateEntity SceneStateEntity { get; }

        [SerializeField] private SceneName initialSceneName;

        private SceneName InitialSceneName => initialSceneName;

        void IInitializable.Initialize()
        {
            // こんな感じに、 Inject した Entity に対して命令するコトで、UseCase への指示出しなどが行える
            LoadRequestEntity.RequestLoad(InitialSceneName);
        }
    }
}