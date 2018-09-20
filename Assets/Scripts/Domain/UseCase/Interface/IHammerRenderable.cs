using CAFU.Core;
using ExtraUniRx;
using UnityEngine;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IHammerRenderable : IPresenter
    {
        void Render(int moleIndex, ITenseSubject<int> attackSubject, Transform moleTransform);
    }
}