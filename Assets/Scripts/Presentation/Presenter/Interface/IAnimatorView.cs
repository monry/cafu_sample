using CAFU.Core.Presentation.View;
using UnityEngine;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IAnimatorView : IView
    {
        Animator Animator { get; }
    }
}