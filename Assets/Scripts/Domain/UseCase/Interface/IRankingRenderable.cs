using CAFU.Core;
using Monry.CAFUSample.Domain.Structure;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IRankingRenderable : IPresenter
    {
        void RenderRanking(IRankingList rankingList);
    }
}