using System;
using UniRx;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IRankingSaveTrigger
    {
        IObservable<Unit> SaveRankingAsObservable();
    }
}