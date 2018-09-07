using Application.Enumerate;
using CAFU.Scene.Domain.Entity;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.System
{
    public class SystemController : MonoBehaviour, IInitializable
    {
        [Inject] private ILoaderRequestEntity LoaderRequestEntity { get; }

        [SerializeField] private SceneName sceneName;

        private SceneName SceneName => sceneName;

        public void Initialize()
        {
            // こんな感じに、 Inject した Entity に対して命令するコトで、UseCase への指示出しなどが行える
            if (SceneName != SceneName.System && !LoaderRequestEntity.HasLoaded(SceneName))
            {
                LoaderRequestEntity.RequestLoad(SceneName);
            }
        }
    }
}