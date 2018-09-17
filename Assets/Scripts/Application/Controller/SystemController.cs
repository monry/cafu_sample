using System;
using Monry.CAFUSample.Application.Enumerate;
using CAFU.Scene.Domain.Entity;
using CAFU.Scene.Presentation.Presenter;
using CAFU.Zenject.Utility;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class SystemController : MonoBehaviour,
        IInitializable,
        IInstancePublisher,
        ISceneLoadRequestable
    {
        [Inject] private ISceneStateEntity SceneStateEntity { get; }
        [Inject] IMessagePublisher IInstancePublisher.MessagePublisher { get; }

        [SerializeField] private SceneName initialSceneName;

        private SceneName InitialSceneName => initialSceneName;

        private ISubject<SceneName> RequestLoadSubject { get; } = new Subject<SceneName>();

        void IInitializable.Initialize()
        {
            // インスタンス生成を通知
            //   CAFU Scene に対してインスタンスを通知して、Load/Unload のリクエストを処理させる
            this.Publish();

            RequestLoadSubject.OnNext(InitialSceneName);
        }

        public IObservable<string> RequestLoadAsObservable()
        {
            return RequestLoadSubject.Select(x => x.ToString());
        }
    }
}