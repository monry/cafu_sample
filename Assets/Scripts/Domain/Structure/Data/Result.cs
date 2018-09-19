using System;
using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure.Data
{
    public interface IResult : IStructure
    {
        int Score { get; }
        string PlayerName { get; }
        DateTime PlayedAt { get; }
    }

    [Serializable]
    public struct Result : IResult
    {
        [SerializeField] private int score;
        [SerializeField] private string playerName;
        [SerializeField] private DateTime playedAt;

        public Result(int score, string playerName, DateTime playedAt)
        {
            this.score = score;
            this.playerName = playerName;
            this.playedAt = playedAt;
        }

        public int Score => score;
        public string PlayerName => playerName;
        public DateTime PlayedAt => playedAt;
    }
}