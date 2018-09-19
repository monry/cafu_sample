using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure.Presentation;

namespace Monry.CAFUSample.Domain.Translator
{
    public class ResultTranslator : ITranslator<IResultEntity, IResult>
    {
        public IResult Translate(IResultEntity param1)
        {
            return new Result(param1.Score, param1.PlayerName, param1.PlayedAt);
        }
    }
}