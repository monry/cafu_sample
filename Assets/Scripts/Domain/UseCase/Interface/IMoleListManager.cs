using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IMoleListManager : IPresenter
    {
        Transform GetMoleTransform(int index);
    }
}