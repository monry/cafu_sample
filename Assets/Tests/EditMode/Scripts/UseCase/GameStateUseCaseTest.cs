using Monry.CAFUSample.Application;
using Monry.CAFUSample.Entity;
using Moq;
using NUnit.Framework;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.UseCase
{
    public class GameStateUseCaseTest : ZenjectUnitTestFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();

            Container.Bind<IGameStateEntity>().FromMock();
            Container.Bind<IGameScoreRenderablePresenter>().FromMock();
            Container.Bind<GameStateUseCase>().AsCached();
            Container.Bind<IInitializable>().To<GameStateUseCase>().FromResolve();
        }

        [Test]
        public void ResetScoreTest()
        {
            var rp = new IntReactiveProperty();

            var mock = new Mock<IGameStateEntity>();
            mock.Setup(x => x.Score).Returns(rp);
            Container.Rebind<IGameStateEntity>().FromInstance(mock.Object);

            var useCase = Container.Resolve<GameStateUseCase>();

            // Default value
            Assert.AreEqual(0, mock.Object.Score.Value);

            // Change value
            rp.Value = 10;
            Assert.AreEqual(10, mock.Object.Score.Value);

            // Reset value
            useCase.ResetScore();
            Assert.AreEqual(0, mock.Object.Score.Value);
        }

        [Test]
        public void RenderScoreTest()
        {
            var rp = new IntReactiveProperty();

            // Mocking
            var mockPresenter = new Mock<IGameScoreRenderablePresenter>();
            Container.Rebind<IGameScoreRenderablePresenter>().FromInstance(mockPresenter.Object);

            var mockModel = new Mock<IGameStateEntity>();
            mockModel.Setup(x => x.Score).Returns(rp);
            Container.Rebind<IGameStateEntity>().FromInstance(mockModel.Object);

            // fire IInitializable.Initialize()
            Container.ResolveAll<IInitializable>().ForEach(x => x.Initialize());

            rp.Value = 10;
            // Assert method passed
            mockPresenter.Verify(m => m.RenderScore(10));
        }

        public void RemainingTimeTest()
        {
            var rp = new FloatReactiveProperty(Constant.RemainingTime);

            // Mocking
            var mockModel = new Mock<IGameStateEntity>();
            mockModel.Setup(x => x.RemainingTime).Returns(rp);
            Container.Rebind<IGameStateEntity>().FromInstance(mockModel.Object);

            // fire IInitializable.Initialize()
            Container.ResolveAll<IInitializable>().ForEach(x => x.Initialize());
        }
    }
}