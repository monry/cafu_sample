using System;
using System.Collections.Generic;
using CAFU.Core.Domain.UseCase;
using ExtraLinq;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleUseCase
    {
    }

    public class MoleUseCase : IMoleUseCase
    {
        // XXX: コンストラクタ引数でも良いかも
        [Inject] private MolePresenter.Factory MolePresenterFactory { get; }
//        private IMolePresenter MolePresenter { get; }

        public void Foo()
        {
            Debug.Log("Foo");
        }

        [Inject]
        public void Initialize(IMoleEntity moleEntity)
        {
            Debug.Log("MoleUseCase.ctor()");
            MolePresenterFactory.Create(moleEntity);
            Debug.Log($"MoleUseCase.Initialize(): {moleEntity.Index}");
            var nextActionMap = new[]
            {
                new KeyValuePair<string, Action>(Constant.Animator.AnimationStateName.Show, moleEntity.Show),
                new KeyValuePair<string, Action>(Constant.Animator.AnimationStateName.Feint, moleEntity.Feint),
            };
            moleEntity
                .DidActiveSubject
                .Delay(TimeSpan.FromSeconds(Constant.MoleActiveDuration))
                .Where(_ => moleEntity.IsActive?.Invoke() ?? false)
                .Subscribe(_ => moleEntity.Hide?.Invoke());
            moleEntity
                .DidInactiveSubject
                .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(Random.Range(Constant.MoleInactiveDurationFrom, Constant.MoleInactiveDurationTo))))
                .Select(_ => nextActionMap.Random())
                .Subscribe(x => x.Value?.Invoke());
        }

        public class Factory : PlaceholderFactory<IMoleEntity, IMoleUseCase>
        {
        }
    }
}