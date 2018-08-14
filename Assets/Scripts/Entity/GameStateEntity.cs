using CAFU.Core.Domain.Model;
using Monry.CAFUSample.Application;
using UniRx;

namespace Monry.CAFUSample.Entity
{
    public interface IGameStateEntity
    {
        IReactiveProperty<int> Score { get; }

        IReactiveProperty<float> RemainingTime { get; }
    }

    public class GameStateEntity : IGameStateEntity
    {
        public IReactiveProperty<int> Score { get; } = new IntReactiveProperty();
        public IReactiveProperty<float> RemainingTime { get; } = new FloatReactiveProperty(Constant.RemainingTime);
    }
}