using System;
using System.Globalization;
using System.Linq;
using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;

namespace Monry.CAFUSample.Domain.Translator
{
    public class ResultListTranslator :
        ITranslator<Structure.Data.IResultList, IResultListEntity>,
        ITranslator<IResultListEntity, Structure.Data.IResultList>,
        ITranslator<IResultListEntity, Structure.Presentation.IResultList>
    {
        IResultListEntity ITranslator<Structure.Data.IResultList, IResultListEntity>.Translate(Structure.Data.IResultList param1)
        {
            return new ResultListEntity(param1.List.Select(x => new ResultEntity(x.Score, x.PlayerName, DateTime.Parse(x.PlayedAt))).ToList());
        }

        Structure.Data.IResultList ITranslator<IResultListEntity, Structure.Data.IResultList>.Translate(IResultListEntity param1)
        {
            return new Structure.Data.ResultList(param1.List.Select(x => new Structure.Data.Result(x.Score, x.PlayerName, x.PlayedAt.ToString(CultureInfo.CurrentCulture))).ToList());
        }

        Structure.Presentation.IResultList ITranslator<IResultListEntity, Structure.Presentation.IResultList>.Translate(IResultListEntity param1)
        {
            return new Structure.Presentation.ResultList(param1.List.Select(x => new Structure.Presentation.Result(x.Score, x.PlayerName, x.PlayedAt)).ToList());
        }
    }
}