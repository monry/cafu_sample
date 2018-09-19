using System;
using System.Globalization;
using System.Linq;
using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using Zenject;

namespace Monry.CAFUSample.Domain.Translator
{
    public class ResultTranslator :
        ITranslator<IResultEntity, IPresentationResult>,
        ITranslator<IDataResultList, IResultListEntity>,
        ITranslator<IResultListEntity, IDataResultList>,
        ITranslator<IResultListEntity, IPresentationResultList>
    {
        [Inject] private IFactory<int, string, DateTime, IPresentationResult> PresentationResultStructureFactory { get; }
        [Inject] private IFactory<int, string, string, IDataResult> DataResultStructureFactory { get; }
        [Inject] private IFactory<int, string, DateTime, IResultEntity> ResultEntityFactory { get; }

        IPresentationResult ITranslator<IResultEntity, IPresentationResult>.Translate(IResultEntity param1)
        {
            return PresentationResultStructureFactory.Create(param1.Score, param1.PlayerName, param1.PlayedAt);
        }

        IResultListEntity ITranslator<IDataResultList, IResultListEntity>.Translate(IDataResultList param1)
        {
            return new ResultListEntity(param1.List.Select(x => ResultEntityFactory.Create(x.Score, x.PlayerName, DateTime.Parse(x.PlayedAt))).ToList());
        }

        IDataResultList ITranslator<IResultListEntity, IDataResultList>.Translate(IResultListEntity param1)
        {
            return new DataResultList(param1.List.Select(x => DataResultStructureFactory.Create(x.Score, x.PlayerName, x.PlayedAt.ToString(CultureInfo.CurrentCulture))).ToList());
        }

        IPresentationResultList ITranslator<IResultListEntity, IPresentationResultList>.Translate(IResultListEntity param1)
        {
            return new PresentationResultList(param1.List.Select(((ITranslator<IResultEntity, IPresentationResult>) this).Translate).ToList());
        }
    }
}