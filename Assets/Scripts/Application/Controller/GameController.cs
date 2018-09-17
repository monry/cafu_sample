using System;
using CAFU.Scene.Presentation.Presenter;
using CAFU.Zenject.Utility;
using Monry.CAFUSample.Domain.Entity;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class GameController : MonoBehaviour,
        IInitializable,
        ISceneLoadRequestable,
        ISceneUnloadRequestable,
        IInstancePublisher
    {
        [Inject] private IGameStateEntity GameStateEntity { get; }
        [Inject] IMessagePublisher IInstancePublisher.MessagePublisher { get; }
        private ISubject<string> RequestLoadSubject { get; } = new Subject<string>();
        private ISubject<string> RequestUnloadSubject { get; } = new Subject<string>();

        void IInitializable.Initialize()
        {
            // インスタンス生成を通知
            //   CAFU Scene に対してインスタンスを通知して、Load/Unload のリクエストを処理させる
            this.Publish();

            Observable
                .Timer(TimeSpan.FromSeconds(3.0))
                .AsUnitObservable()
                .Subscribe(GameStateEntity.WillStartSubject);
            Observable.Timer(TimeSpan.FromSeconds(5.0)).Subscribe(_ => RequestLoadSubject.OnNext("SampleGameResult"));
            Observable.Timer(TimeSpan.FromSeconds(15.0)).Subscribe(_ => RequestUnloadSubject.OnNext("SampleGame"));
//            GameStateEntity.WillStopSubject.Delay(TimeSpan.FromSeconds(3)).Subscribe(_ => UnloadRequest.Request("Game"));
        }

        public IObservable<string> RequestLoadAsObservable()
        {
            return RequestLoadSubject;
        }

        public IObservable<string> RequestUnloadAsObservable()
        {
            return RequestUnloadSubject;
        }
    }
}