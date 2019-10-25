namespace CAFUSample.Data.Repository.Interface.DataStore
{
    public interface IRecordRecorder
    {
        void Add(string playerName, int hitCount);
    }
}