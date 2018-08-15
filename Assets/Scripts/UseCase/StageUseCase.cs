using CAFU.Core;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using Zenject;

namespace Monry.CAFUSample.UseCase
{
    public class StageUseCase : IUseCase, IInitializable
    {
        [Inject] private PlaceholderFactory<IMoleEntity, IMoleUseCase> MoleUseCaseFactory { get; }

        [Inject] private PlaceholderFactory<int, IMoleEntity> MoleEntityFactory { get; }

        [Inject] private IGameStateEntity GameStateModel { get; }

        public void Attacked()
        {
            GameStateModel.Score.Value++;
        }

        void IInitializable.Initialize()
        {
            for (var i = 0; i < Constant.MoleAmount; i++)
            {
                MoleUseCaseFactory.Create(MoleEntityFactory.Create(i));
            }
        }
    }
}