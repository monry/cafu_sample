using System;
using Monry.CAFUSample.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Monry.CAFUSample.Presentation.View.GameResult
{
    [RequireComponent(typeof(InputField))]
    public class PlayerName : MonoBehaviour,
        IInitializable,
        IPlayerNameReceiver,
        IPlayerNameRenderer
    {
        [SerializeField] private InputField inputField;
        private InputField InputField => inputField ? inputField : inputField = GetComponent<InputField>();

        private ISubject<string> OnReceiveNameSubject { get; } = new Subject<string>();

        void IInitializable.Initialize()
        {
            InputField.onValueChanged.AddListener(OnReceiveNameSubject.OnNext);
        }

        public IObservable<string> OnReceiveAsObservable()
        {
            return OnReceiveNameSubject;
        }

        public void Render(string playerName)
        {
            InputField.text = playerName;
        }
    }
}