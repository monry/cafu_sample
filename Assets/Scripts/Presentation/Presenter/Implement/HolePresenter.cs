using System.Collections.Generic;
using CAFUSample.Application.ValueObject.Transaction;
using CAFUSample.Domain.UseCase.Interface.Presenter;
using UniFlow;

namespace CAFUSample.Presentation.Presenter.Implement
{
    public class HolePresenter : IHolesRenderer
    {
        public HolePresenter(IInjectable<IEnumerable<Hole>> holesInjectable)
        {
            HolesInjectable = holesInjectable;
        }

        private IInjectable<IEnumerable<Hole>> HolesInjectable { get; }

        void IHolesRenderer.Render(IEnumerable<Hole> holes)
        {
            HolesInjectable.Inject(holes);
        }
    }
}