using Monry.CAFUSample.Presentation.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace Monry.CAFUSample.Presentation.View.Game
{
    public class Score : MonoBehaviour,
        IScoreView
    {
        private Text label;
        private Text Label => label ? label : label = GetComponent<Text>();

        public void Render(int score)
        {
            Label.text = score.ToString();
        }
    }
}