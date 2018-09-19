using CAFU.Core;
using Monry.CAFUSample.Domain.Structure.Presentation;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IRankingRenderable : IPresenter
    {
        void RenderRanking(IRanking ranking);
    }
}