using CAFUSample.Application.ValueObject.Master;
using CAFUSample.Data.Repository.Interface.DataStore;

namespace CAFUSample.Data.DataStore.Implement
{
    public class GameSettingDataStore : IGameSettingReader
    {
        public GameSettingDataStore(GameSetting gameSetting)
        {
            GameSetting = gameSetting;
        }

        private GameSetting GameSetting { get; }

        float IGameSettingReader.ReadDurationSeconds()
        {
            return GameSetting.DurationSeconds;
        }

        int IGameSettingReader.ReadHoleAmount()
        {
            return GameSetting.HoleAmount;
        }
    }
}