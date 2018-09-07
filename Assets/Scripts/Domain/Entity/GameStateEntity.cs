using CAFU.Core;
using Monry.CAFUSample.Application;
using UniRx;

namespace Monry.CAFUSample.Domain.Entity
{
    public interface IGameStateEntity : IEntity
    {
        IReactiveProperty<int> Score { get; }
        IReactiveProperty<float> RemainingTime { get; }
        ISubject<Unit> WillStartSubject { get; }
        ISubject<Unit> WillStopSubject { get; }
        ISubject<Unit> WillPauseSubject { get; }
        ISubject<Unit> WillResumeSubject { get; }
        ISubject<Unit> WillFinishSubject { get; }
    }

    public class GameStateEntity : IGameStateEntity
    {
        public IReactiveProperty<int> Score { get; } = new IntReactiveProperty();
        public IReactiveProperty<float> RemainingTime { get; } = new FloatReactiveProperty(Constant.RemainingTime);
        public ISubject<Unit> WillStartSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> WillStopSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> WillPauseSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> WillResumeSubject { get; } = new Subject<Unit>();
        public ISubject<Unit> WillFinishSubject { get; } = new Subject<Unit>();
    }
}