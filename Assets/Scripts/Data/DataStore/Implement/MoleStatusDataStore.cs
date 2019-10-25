using CAFUSample.Application.ValueObject.Transaction;

namespace CAFUSample.Data.DataStore.Implement
{
    public class MoleStatusDataStore
    {
        public MoleStatusDataStore(MoleStatus moleStatus)
        {
            MoleStatus = moleStatus;
        }

        private MoleStatus MoleStatus { get; }
    }
}