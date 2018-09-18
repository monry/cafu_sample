using System;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class TitlePresenter : ITitleNavigator
    {
        [Inject(Id = Constant.InjectId.ButtonStart)]
        private ITrigger TriggerStart { get; }

        [Inject(Id = Constant.InjectId.ButtonRanking)]
        private ITrigger TriggerRanking { get; }

        public IObservable<Unit> OnNavigateToGameAsObservable()
        {
            return TriggerStart.OnTriggerAsObservable();
        }

        public IObservable<Unit> OnNavigateToRankingAsObservable()
        {
            return TriggerRanking.OnTriggerAsObservable();
        }
    }
}