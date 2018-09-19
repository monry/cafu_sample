using System.Linq;
using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure.Data;

namespace Monry.CAFUSample.Domain.Translator
{
    public class RankingTranslator :
        ITranslator<IRanking, IRankingEntity>,
        ITranslator<IRankingEntity, IRanking>
    {
        public IRankingEntity Translate(IRanking param1)
        {
            return new RankingEntity(param1.ResultList.Select(x => new ResultEntity(x.Score, x.PlayerName, x.PlayedAt)).ToList());
        }

        public IRanking Translate(IRankingEntity param1)
        {
            return new Ranking(param1.ResultEntityList.Select(x => new Result(x.Score, x.PlayerName, x.PlayedAt)).ToList());
        }
    }
}