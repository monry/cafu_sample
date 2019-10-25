using System.Collections.Generic;
using CAFUSample.Application.ValueObject.Transaction;

namespace CAFUSample.Domain.UseCase.Interface.Presenter
{
    public interface IHolesRenderer
    {
        void Render(IEnumerable<Hole> holes);
    }
}