using CAFU.Core.Domain.Translator;
using CAFUSample.Data.Entity;

namespace CAFUSample.Domain.Translator
{
    public class ScoreEntityTranslator : IEntityTranslator<int, IScoreEntity>
    {
        public IScoreEntity Translate(int score)
        {
            throw new System.NotImplementedException();
        }
    }
}