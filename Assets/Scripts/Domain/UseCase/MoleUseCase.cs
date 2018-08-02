using CAFU.Core.Domain.UseCase;
using Monry.CAFUSample.Domain.Model;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class MoleUseCase : IUseCase, IInitializable
    {
        [Inject] private IGameStateModel GameStateModel { get; }

        [Inject] private IMoleSpawnablePresenter MoleSpawnablePresenter { get; }

        public void Attacked()
        {
            GameStateModel.Score.Value++;
        }

        public void Foo()
        {
            UnityEngine.Debug.Log("Foo");
        }

        void IInitializable.Initialize()
        {
            UnityEngine.Debug.Log("MoleUseCase.Initialize()");
            MoleSpawnablePresenter.SpawnMoles();
        }

        public MoleUseCase()
        {
            UnityEngine.Debug.Log("MoleUseCase.ctor()");
        }
    }
}