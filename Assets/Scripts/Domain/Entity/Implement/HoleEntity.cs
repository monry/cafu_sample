using System.Linq;
using CAFUSample.Application.ValueObject.Master;
using CAFUSample.Application.ValueObject.Transaction;
using CAFUSample.Domain.Entity.Interface.UseCase;
using UnityEngine;
using Zenject;

namespace CAFUSample.Domain.Entity.Implement
{
    public class HoleEntity : IInitializable
    {
        public HoleEntity(GameSetting gameSetting, IHolesHandler holesHandler)
        {
            GameSetting = gameSetting;
            HolesHandler = holesHandler;
        }

        private GameSetting GameSetting { get; }
        private IHolesHandler HolesHandler { get; }

        void IInitializable.Initialize()
        {
            HolesHandler
                .RenderHoles(
                    Enumerable
                        .Range(0, GameSetting.HoleAmount)
                        .Select(_ => Hole.Create(CreateRandomPosition()))
                );
        }

        private Vector2 CreateRandomPosition()
        {
            return new Vector2(
                Random.Range(GameSetting.HolePositionRangeX.x, GameSetting.HolePositionRangeX.y),
                Random.Range(GameSetting.HolePositionRangeY.x, GameSetting.HolePositionRangeY.y)
            );
        }
    }
}