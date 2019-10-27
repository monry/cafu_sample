using System.Collections.Generic;
using System.Linq;
using CAFUSample.Application.ValueObject.Transaction;
using CAFUSample.Data.Repository.Interface.DataStore;
using UnityEngine;

namespace CAFUSample.Data.DataStore.Implement
{
    public class RecordDataStore : IRecordRecorder, IRecordLoader
    {
        private static readonly string PlayerPrefsKey = $"{typeof(Records).AssemblyQualifiedName}";

        public RecordDataStore(Records records)
        {
            Records = records;
            Load();
        }

        private Records Records { get; }

        private void Load()
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(PlayerPrefsKey, "{}"), Records);
        }

        private void Save()
        {
            PlayerPrefs.SetString(PlayerPrefsKey, JsonUtility.ToJson(Records));
            PlayerPrefs.Save();
        }

        void IRecordRecorder.Add(string playerName, int hitCount)
        {
            Records.List.Add(Record.Create(playerName, hitCount));
            Save();
        }

        IEnumerable<Record> IRecordLoader.LoadRanking(int limit)
        {
            return Records.List.OrderByDescending(x => x.HitCount).Take(limit);
        }
    }
}