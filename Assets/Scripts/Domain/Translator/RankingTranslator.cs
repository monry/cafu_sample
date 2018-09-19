using System;
using System.Globalization;
using System.Linq;
using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;

namespace Monry.CAFUSample.Domain.Translator
{
    public class RankingTranslator :
        ITranslator<Structure.Data.IRanking, IRankingEntity>,
        ITranslator<IRankingEntity, Structure.Data.IRanking>,
        ITranslator<IRankingEntity, Structure.Presentation.IRanking>
    {
        IRankingEntity ITranslator<Structure.Data.IRanking, IRankingEntity>.Translate(Structure.Data.IRanking param1)
        {
            return new RankingEntity(param1.ResultList.Select(x => new ResultEntity(x.Score, x.PlayerName, DateTime.Parse(x.PlayedAt))).ToList());
        }

        Structure.Data.IRanking ITranslator<IRankingEntity, Structure.Data.IRanking>.Translate(IRankingEntity param1)
        {
            return new Structure.Data.Ranking(param1.ResultEntityList.Select(x => new Structure.Data.Result(x.Score, x.PlayerName, x.PlayedAt.ToString(CultureInfo.CurrentCulture))).ToList());
        }

        Structure.Presentation.IRanking ITranslator<IRankingEntity, Structure.Presentation.IRanking>.Translate(IRankingEntity param1)
        {
            return new Structure.Presentation.Ranking(param1.ResultEntityList.Select(x => new Structure.Presentation.Result(x.Score, x.PlayerName, x.PlayedAt)).ToList());
        }
    }
}