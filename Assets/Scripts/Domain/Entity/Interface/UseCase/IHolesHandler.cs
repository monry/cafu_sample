using System.Collections.Generic;
using CAFUSample.Application.ValueObject.Transaction;

namespace CAFUSample.Domain.Entity.Interface.UseCase
{
    public interface IHolesHandler
    {
        void RenderHoles(IEnumerable<Hole> holes);
    }
}