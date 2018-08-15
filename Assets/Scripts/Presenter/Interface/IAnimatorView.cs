using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Presenter
{
    public interface IAnimatorView : IView
    {
        Animator Animator { get; }
    }
}