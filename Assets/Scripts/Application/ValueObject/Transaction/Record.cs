using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace CAFUSample.Application.ValueObject.Transaction
{
    [Serializable]
    [PublicAPI]
    public class Record
    {
        private Record()
        {
        }

        [SerializeField] private string playerName = default;
        [SerializeField] private int hitCount = default;
        [SerializeField] private DateTime playedAt = default;

        public string PlayerName
        {
            get => playerName;
            private set => playerName = value;
        }
        public int HitCount
        {
            get => hitCount;
            private set => hitCount = value;
        }
        public DateTime PlayedAt
        {
            get => playedAt;
            private set => playedAt = value;
        }

        public static Record Create(string playerName, int hitCount)
        {
            return Create(playerName, hitCount, DateTime.Now);
        }

        public static Record Create(string playerName, int hitCount, DateTime playedAt)
        {
            return new Record
            {
                PlayerName = playerName,
                HitCount = hitCount,
                PlayedAt = playedAt,
            };
        }
    }

    [Serializable]
    public class Records
    {
        [SerializeField] private List<Record> list = new List<Record>();
        public IList<Record> List => list;
    }
}