using CAFU.Core.Domain.Translator;
using Monry.CAFUSample.Data.Entity;

namespace Monry.CAFUSample.Domain.Translator
{
    public class ScoreEntityTranslator : IEntityTranslator<int, IScoreEntity>
    {
        public IScoreEntity Translate(int score)
        {
            throw new System.NotImplementedException();
        }
    }
}