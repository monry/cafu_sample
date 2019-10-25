using System.Collections.Generic;
using CAFUSample.Application.ValueObject.Transaction;

namespace CAFUSample.Data.Repository.Interface.DataStore
{
    public interface IRecordLoader
    {
        IEnumerable<Record> LoadRanking(int limit);
    }
}