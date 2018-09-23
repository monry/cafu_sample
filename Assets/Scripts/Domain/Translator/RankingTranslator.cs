using System.Collections.Generic;
using System.Linq;
using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using Zenject;

namespace Monry.CAFUSample.Domain.Translator
{
    public class RankingTranslator :
        ITranslator<IResultListEntity, IRankingList>
    {
        [Inject] private ITranslator<IResultEntity, IPresentationResult> ResultStructureTranslator { get; }
        [Inject] private IFactory<int, IPresentationResult, IRanking> RankingStructureFactory { get; }
        [Inject] private IFactory<IEnumerable<IRanking>, IRankingList> RankingListStructureFactory { get; }

        public IRankingList Translate(IResultListEntity param1)
        {
            var resultList = param1.List.Select(ResultStructureTranslator.Translate).ToList();
            var ranking = resultList
                .Select(r1 => new {r1, higher = resultList.Where(r2 => r2.Score > r1.Score)})
                .Select(t => RankingStructureFactory.Create(t.higher.Count() + 1, t.r1))
                .OrderBy(r3 => r3.Rank);
            return RankingListStructureFactory.Create(ranking);
        }
    }
}