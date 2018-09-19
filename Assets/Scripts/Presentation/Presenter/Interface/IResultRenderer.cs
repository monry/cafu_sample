using CAFU.Core;
using Monry.CAFUSample.Domain.Structure.Presentation;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IResultRenderer : IView
    {
        void Render(int rank, IResult result);
    }
}