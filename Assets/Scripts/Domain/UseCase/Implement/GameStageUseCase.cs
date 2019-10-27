using System.Collections.Generic;
using CAFUSample.Application.ValueObject.Transaction;
using CAFUSample.Domain.Entity.Interface.UseCase;
using CAFUSample.Domain.UseCase.Interface.Presenter;
using Zenject;

namespace CAFUSample.Domain.UseCase.Implement
{
    public class GameStageUseCase : IInitializable, IHolesHandler
    {
        public GameStageUseCase(IHolesRenderer holesRenderer)
        {
            HolesRenderer = holesRenderer;
        }

        private IHolesRenderer HolesRenderer { get; }

        void IInitializable.Initialize()
        {

        }

        void IHolesHandler.RenderHoles(IEnumerable<Hole> holes)
        {
            HolesRenderer.Render(holes);
        }
    }
}