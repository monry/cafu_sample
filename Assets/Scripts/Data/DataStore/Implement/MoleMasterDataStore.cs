using System.Collections.Generic;
using CAFU.MasterLoader.Application.Delegate;
using CAFU.MasterLoader.Data.DataStore.Implement;
using CAFUSample.Application.ValueObject.Master;

namespace CAFUSample.Data.DataStore.Implement
{
    public class MoleMasterDataStore : MasterDataStoreBase<MoleType, MoleMaster>
    {
        public MoleMasterDataStore(IEnumerable<MoleMaster> masters, MasterPredicate<MoleType, MoleMaster> predicate) : base(masters, predicate)
        {
        }
    }
}