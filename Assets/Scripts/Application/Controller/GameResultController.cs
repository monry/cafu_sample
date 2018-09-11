using System;
using Monry.CAFUSample.Application.Enumerate;
using CAFU.Scene.Domain.Entity;
using Monry.CAFUSample.Domain.Entity;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Controller
{
    public class GameResultController : MonoBehaviour, IInitializable
    {
        [Inject] private IScoreEntity ScoreEntity { get; }
        [Inject] private ILoadRequestEntity LoadRequestEntity { get; }

        void IInitializable.Initialize()
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ => Debug.Log(ScoreEntity.Current.Value)).AddTo(this);
            Observable.Timer(TimeSpan.FromSeconds(5)).Subscribe(_ => LoadRequestEntity.RequestUnload(SceneName.GameResult));
        }
    }
}