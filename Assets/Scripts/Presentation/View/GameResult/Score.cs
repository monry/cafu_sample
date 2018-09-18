using Monry.CAFUSample.Presentation.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace Monry.CAFUSample.Presentation.View.GameResult
{
    [RequireComponent(typeof(Text))]
    public class Score : MonoBehaviour, IScoreRenderer
    {
        [SerializeField] private Text text;
        private Text Text => text ? text : text = GetComponent<Text>();

        public void Render(int score)
        {
            Text.text = score.ToString();
        }
    }
}