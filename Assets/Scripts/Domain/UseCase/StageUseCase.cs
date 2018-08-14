using CAFU.Core.Domain.UseCase;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class StageUseCase : IUseCase, IInitializable
    {
        [Inject] private MoleUseCase.Factory MoleUseCaseFactory { get; }

        [Inject] private MoleEntity.Factory MoleEntityFactory { get; }

        [Inject] private IGameStateEntity GameStateModel { get; }

//        [Inject] private IMoleSpawnablePresenter MoleSpawnablePresenter { get; }

        public void Attacked()
        {
            GameStateModel.Score.Value++;
        }

        void IInitializable.Initialize()
        {
            Debug.Log("StageUseCase.Initialize()");
            for (var i = 0; i < Constant.MoleAmount; i++)
            {
                MoleUseCaseFactory.Create(MoleEntityFactory.Create(i));
//                var moleUseCase = MoleUseCaseFactory.Create(MoleEntityFactory.Create(i));
//                MoleSpawnablePresenter.SpawnMole(MoleEntityFactory.Create(i));
            }
        }
    }
}