using CAFU.Core;
using Monry.CAFUSample.Domain.Structure;

namespace Monry.CAFUSample.Presentation.Presenter
{
    public interface IResultRenderer : IView
    {
        void Render(int rank, IPresentationResult presentationResult);
    }
}