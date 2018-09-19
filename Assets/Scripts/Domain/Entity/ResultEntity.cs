using System;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Entity
{
    public interface IResultEntity : IEntity
    {
        int Score { get; }
        string PlayerName { get; }
        DateTime PlayedAt { get; }
        void UpdatePlayerName(string playerName);
    }

    public class ResultEntity : IResultEntity
    {
        public ResultEntity(int score, string playerName, DateTime playedAt = default(DateTime))
        {
            Score = score;
            PlayerName = playerName;
            PlayedAt = playedAt == default(DateTime) ? DateTime.Now : playedAt;
        }

        public int Score { get; }
        public string PlayerName { get; private set; }
        public DateTime PlayedAt { get; }

        public void UpdatePlayerName(string playerName)
        {
            PlayerName = playerName;
        }
    }
}