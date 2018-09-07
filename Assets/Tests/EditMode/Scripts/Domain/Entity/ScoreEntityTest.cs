using Monry.CAFUSample.Domain.UseCase;
using NUnit.Framework;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.Entity
{
    public class ScoreEntityTest : ZenjectUnitTestFixture
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();

            Container.BindInterfacesTo<GameStateEntity>().AsCached();
            Container.BindInterfacesTo<ScoreEntity>().AsCached();

            Container.Bind<IGameScoreRenderablePresenter>().FromMock();
            Container.BindInterfacesAndSelfTo<GameStateUseCase>().AsCached();
        }

        [Test]
        public void IncrementTest()
        {
            // EditMode Tests から IInitializable.Initialize() は呼ばれない？
            (Container.Resolve<GameStateUseCase>() as IInitializable).Initialize();

            var gameStateEntity = Container.Resolve<IGameStateEntity>();
            var scoreEntity = Container.Resolve<IScoreEntity>();

            Assert.AreEqual(0, scoreEntity.Current.Value);
            gameStateEntity.WillAttackSubject.OnNext(Unit.Default);
            Assert.AreEqual(1, scoreEntity.Current.Value);
            gameStateEntity.WillAttackSubject.OnNext(Unit.Default);
            Assert.AreEqual(2, scoreEntity.Current.Value);
        }
    }
}