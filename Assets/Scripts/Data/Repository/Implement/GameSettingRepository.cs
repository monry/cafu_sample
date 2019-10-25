using CAFUSample.Data.Repository.Interface.DataStore;
using CAFUSample.Domain.UseCase.Interface.Repository;
using UniRx.Async;

namespace CAFUSample.Data.Repository.Implement
{
    public class GameSettingRepository : IStageSettingReader
    {
        public GameSettingRepository(IGameSettingReader gameSettingReader)
        {
            GameSettingReader = gameSettingReader;
        }

        private IGameSettingReader GameSettingReader { get; }

        async UniTask<(float durationSeconds, int holeAmount)> IStageSettingReader.Read()
        {
            return await UniTask.FromResult((GameSettingReader.ReadDurationSeconds(), GameSettingReader.ReadHoleAmount()));
        }
    }
}