using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.UseCase;
using NUnit.Framework;
using Zenject;

namespace Tests.EditMode.Scripts.Domain.Entity
{
    public class ScoreEntityTest : ZenjectUnitTestFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();

            Container.BindInstance(0).WithId(Constant.InjectId.MoleAmount);

            Container.BindIFactory<int, IMoleEntity>().To<MoleEntity>();
            Container.BindInterfacesTo<GameStateEntity>().AsCached();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            Container.Bind<IMolePresenter>().FromMock();
            // IInitializable は Bind しない
            Container.Bind<MoleUseCase>().AsCached();
        }

        // InitializeMole 内で閉じすぎているのでテスト難しい…
        // Attack を Entity に切り出せればワンチャンあり
//        [Test]
//        public void IncrementTest()
//        {
//            var gameStateEntity = Container.Resolve<IGameStateEntity>();
//            var scoreEntity = Container.Resolve<IScoreEntity>();
//
//            Assert.AreEqual(0, scoreEntity.Current.Value);
//        }
    }
}