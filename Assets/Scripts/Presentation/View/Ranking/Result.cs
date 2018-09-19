using System.Collections.Generic;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Presentation.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace Monry.CAFUSample.Presentation.View.Ranking
{
    public class Result : MonoBehaviour, IResultRenderer
    {
        private static readonly Dictionary<int, Color> ColorMap = new Dictionary<int, Color>
        {
            { 0, Color.white },
            { 1, new Color(0.75f, 0.75f, 0.75f, 1.0f) },
        };

        [SerializeField] private Image background;
        [SerializeField] private Text rank;
        [SerializeField] private Text playerName;
        [SerializeField] private Text playedAt;
        [SerializeField] private Text score;
        private Image Background => background;
        private Text Rank => rank;
        private Text PlayerName => playerName;
        private Text PlayedAt => playedAt;
        private Text Score => score;

        public void Render(int rankValue, IPresentationResult presentationResult)
        {
            Rank.text = rankValue.ToString();
            Background.color = ColorMap[transform.GetSiblingIndex() % 2];
            PlayerName.text = presentationResult.PlayerName;
            PlayedAt.text = presentationResult.PlayedAt.ToString("yyyy/MM/dd HH:mm:ss");
            Score.text = presentationResult.Score.ToString();
        }
    }
}