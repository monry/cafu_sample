using System;
using System.Collections.Generic;
using ExtraLinq;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using UniRx;
using Zenject;
using Random = UnityEngine.Random;

namespace Monry.CAFUSample.UseCase
{
    public interface IMoleUseCase
    {
    }

    public class MoleUseCase : IMoleUseCase
    {
        [Inject] private PlaceholderFactory<IMoleEntity, IMolePresenter> MolePresenterFactory { get; }

        [Inject] private IGameStateEntity GameStateEntity { get; }

        [Inject]
        public void Initialize(IMoleEntity moleEntity)
        {
            MolePresenterFactory.Create(moleEntity);
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
                .Merge(GameStateEntity.WillStartSubject)
                .SelectMany(_ => Observable.Timer(TimeSpan.FromSeconds(Random.Range(Constant.MoleInactiveDurationFrom, Constant.MoleInactiveDurationTo))))
                .Select(_ => nextActionMap.Random())
                .TakeUntil(GameStateEntity.WillFinishSubject)
                .Subscribe(x => x.Value?.Invoke());
        }
    }
}