namespace CAFUSample.Data.Repository.Interface.DataStore
{
    public interface IGameSettingReader
    {
        float ReadDurationSeconds();
        int ReadHoleAmount();
    }
}