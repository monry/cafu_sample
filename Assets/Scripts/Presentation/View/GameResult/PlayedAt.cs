using System;
using Monry.CAFUSample.Presentation.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace Monry.CAFUSample.Presentation.View.GameResult
{
    [RequireComponent(typeof(Text))]
    public class PlayedAt : MonoBehaviour, IPlayedAtRenderer
    {
        [SerializeField] private Text text;
        private Text Text => text ? text : text = GetComponent<Text>();

        public void Render(DateTime dateTime)
        {
            Text.text = dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}