using System;
using System.Linq;
using Monry.CAFUSample.Domain.Structure.Presentation;
using Monry.CAFUSample.Domain.UseCase;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public class RankingPresenter : IRankingRenderable, IRankingHandler
    {
        [Inject] private IFactory<IResultRenderer> ResultRendererFactory { get; }

        public void RenderRanking(IRanking ranking)
        {
            ranking.ResultList.ToList().ForEach(x => ResultRendererFactory.Create().Render(0, x));
        }

        public IObservable<Unit> LoadAsObservable()
        {
            return Observable.ReturnUnit();
        }

        public IObservable<Unit> SaveAsObservable()
        {
            return Observable.Never<Unit>();
        }
    }
}