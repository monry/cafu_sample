using CAFU.Core;
using ExtraUniRx;
using Monry.CAFUSample.Domain.Entity;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class HammerUseCase : IUseCase, IInitializable
    {
        [Inject] private IMoleListManager MoleListManager { get; }
        [Inject] private IHammerRenderable HammerRenderable { get; }
        [Inject] private IGameStateEntity GameStateEntity { get; }

        void IInitializable.Initialize()
        {
            GameStateEntity
                .AttackSubject
                .WhenDo()
                .Subscribe(x => HammerRenderable.Render(x, GameStateEntity.AttackSubject, MoleListManager.GetMoleTransform(x)));
        }
    }
}