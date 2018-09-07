using CAFU.Core;
using UniRx;

namespace Monry.CAFUSample.Domain.Entity
{
    public interface IScoreEntity : IEntity
    {
        IReactiveProperty<int> Current { get; }
        void Increment();
    }

    public class ScoreEntity : IScoreEntity
    {
        public IReactiveProperty<int> Current { get; } = new IntReactiveProperty();

        public void Increment()
        {
            Current.Value++;
        }
    }
}