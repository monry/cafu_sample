using System;
using CAFU.Scene.Presentation.Presenter;
using CAFU.Zenject.Utility;
using Monry.CAFUSample.Application.Enumerate;
using Monry.CAFUSample.Domain.Entity;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class GameResultController : MonoBehaviour,
        IInitializable,
        ISceneUnloadRequestable,
        IInstancePublisher
    {
        [Inject] private IScoreEntity ScoreEntity { get; }
        [Inject] IMessagePublisher IInstancePublisher.MessagePublisher { get; }
        private ISubject<string> RequestUnloadSubject { get; } = new Subject<string>();

        void IInitializable.Initialize()
        {
            // インスタンス生成を通知
            //   CAFU Scene に対してインスタンスを通知して、Load/Unload のリクエストを処理させる
            this.Publish();

            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ => Debug.Log(ScoreEntity.Current.Value)).AddTo(this);
            Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(_ => RequestUnloadSubject.OnNext(SceneName.SampleGameResult.ToString()));
        }

        // 直接 Subject を公開する手もあるが、厳密に実装してみる
        public IObservable<string> RequestUnloadAsObservable()
        {
            return RequestUnloadSubject;
        }
    }
}