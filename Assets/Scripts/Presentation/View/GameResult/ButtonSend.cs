using System;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Monry.CAFUSample.Presentation.View.GameResult
{
    [RequireComponent(typeof(Button))]
    public class ButtonSend : MonoBehaviour, IResultListSaveTrigger
    {
        [SerializeField] private Button button;
        private Button Button => button ? button : button = GetComponent<Button>();

        private void Start()
        {
            Button.OnClickAsObservable().Subscribe(_ => Button.interactable = false);
        }

        IObservable<Unit> IResultListSaveTrigger.SaveResultListAsObservable()
        {
            return Button.OnClickAsObservable();
        }
    }
}