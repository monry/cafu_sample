using UniRx;
using UniRx.Async;

namespace CAFUSample.Domain.UseCase.Interface.Repository
{
    public interface IStageSettingReader
    {
        UniTask<(float durationSeconds, int holeAmount)> Read();
    }
}