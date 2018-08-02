using Monry.CAFUSample.Presentation.Presenter.Interface;
using Monry.CAFUSample.Presentation.Presenter.Interfaces;
using UnityEngine;

namespace Monry.CAFUSample.Presentation.View.Game
{
    public class Mole : MonoBehaviour, IMoleView, IVisibilityAnimatorView
    {
        private Animator animator;
        public Animator Animator => animator ? animator : (animator = GetComponentInChildren<Animator>());

        public int Index { get; set; }

        private void Start()
        {
            Debug.Log(Animator);
            Debug.Log(Index);
        }
    }
}