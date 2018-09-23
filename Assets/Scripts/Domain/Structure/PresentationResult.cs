using System;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IPresentationResult : IStructure
    {
        int Score { get; }
        string PlayerName { get; }
        DateTime PlayedAt { get; }
    }

    public struct PresentationResult : IPresentationResult
    {
        public PresentationResult(int score, string playerName, DateTime playedAt)
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