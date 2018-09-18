using System;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Structure.Presentation
{
    public interface IResult : IStructure
    {
        int Score { get; }
        string PlayerName { get; }
        DateTime PlayedAt { get; }
    }

    public struct Result : IResult
    {
        public Result(int score, string playerName, DateTime playedAt)
        {
            Score = score;
            PlayerName = playerName;
            PlayedAt = playedAt;
        }

        public int Score { get; }
        public string PlayerName { get; }
        public DateTime PlayedAt { get; }
    }
}