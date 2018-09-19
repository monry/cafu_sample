using System;
using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure.Data
{
    public interface IResult : IStructure
    {
        int Score { get; }
        string PlayerName { get; }
        string PlayedAt { get; }
    }

    [Serializable]
    public struct Result : IResult
    {
        [SerializeField] private int score;
        [SerializeField] private string playerName;
        [SerializeField] private string playedAt;

        public Result(int score, string playerName, string playedAt)
        {
            this.score = score;
            this.playerName = playerName;
            this.playedAt = playedAt;
        }

        public int Score => score;
        public string PlayerName => playerName;
        public string PlayedAt => playedAt;
    }
}