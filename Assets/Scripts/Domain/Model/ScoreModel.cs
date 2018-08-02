using CAFU.Core.Domain.Model;
using Monry.CAFUSample.Application;
using UniRx;

namespace Monry.CAFUSample.Domain.Model
{
    public interface IGameStateModel : IModel
    {
        IReactiveProperty<int> Score { get; }

        IReactiveProperty<float> RemainingTime { get; }
    }

    public class GameStateModel : IGameStateModel
    {
        public IReactiveProperty<int> Score { get; } = new IntReactiveProperty();
        public IReactiveProperty<float> RemainingTime { get; } = new FloatReactiveProperty(Constant.RemainingTime);
    }
}