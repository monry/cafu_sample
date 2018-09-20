using ExtraUniRx;
using Monry.CAFUSample.Domain.UseCase;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class HammerPresenter : IHammerRenderable
    {
        [Inject] private IFactory<int, ITenseSubject<int>, Transform, IHammer> HammerViewFactory { get; }

        public void Render(int moleIndex, ITenseSubject<int> attackSubject, Transform moleTransform)
        {
            HammerViewFactory.Create(moleIndex, attackSubject, moleTransform);
        }
    }
}