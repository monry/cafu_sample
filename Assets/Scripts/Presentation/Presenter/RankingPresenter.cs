using System;
using System.Linq;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Structure;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class RankingPresenter :
        IRankingRenderable,
        IResultListHandler,
        IResultListClearable,
        IRankingNavigator
    {
        [Inject] private IFactory<IResultRenderer> ResultRendererFactory { get; }

        [Inject(Id = Constant.InjectId.ButtonBack)]
        private IButtonTrigger TriggerBack { get; }

        [Inject(Id = Constant.InjectId.ButtonClear)]
        private IButtonTrigger TriggerClear { get; }

        public void RenderRanking(IRankingList rankingList)
        {
            rankingList.List.ToList().ForEach(x => ResultRendererFactory.Create().Render(x));
        }

        public IObservable<Unit> LoadAsObservable()
        {
            return Observable.ReturnUnit();
        }

        public IObservable<Unit> SaveAsObservable()
        {
            return Observable.Never<Unit>();
        }

        public IObservable<Unit> OnNavigateToTitleAsObservable()
        {
            return TriggerBack.OnTriggerAsObservable();
        }

        public IObservable<Unit> ClearAsObservable()
        {
            return TriggerClear.OnTriggerAsObservable();
        }
    }
}