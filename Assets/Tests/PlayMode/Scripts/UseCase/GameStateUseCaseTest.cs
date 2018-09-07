using System.Collections;
using Monry.CAFUSample.Domain.Entity;
using Moq;
using NUnit.Framework;
using UniRx;
using UnityEngine.TestTools;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class GameStateUseCaseTest : ZenjectUnitTestFixture
    {
        [SetUp]
        public void SetUp()
        {
            Container.Bind<IGameStateEntity>().FromMock();
            Container.Bind<IGameScoreRenderablePresenter>().FromMock();
            Container.Bind<GameStateUseCase>().AsTransient();
        }

        [UnityTest]
        public IEnumerator ResetScoreTest()
        {
            var rp = new IntReactiveProperty();
            var mock = new Mock<IGameStateEntity>();
            mock.Setup(x => x.Score).Returns(rp);

            Container.Rebind<IGameStateEntity>().FromInstance(mock.Object);

            var useCase = Container.Resolve<GameStateUseCase>();

            {
                var subscription = rp.First().ToYieldInstruction();
                yield return subscription;
                Assert.AreEqual(0, subscription.Result);
            }

            // Pass しない…
            {
                var subscription = rp.First().ToYieldInstruction();
                rp.Value = 10;
                yield return subscription;
                Assert.AreEqual(10, subscription.Result);
            }

            {
                var subscription = rp.First().ToYieldInstruction();
                useCase.ResetScore();
                yield return subscription;
                Assert.AreEqual(0, subscription.Result);
            }
        }
    }
}