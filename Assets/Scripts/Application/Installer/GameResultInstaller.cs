using CAFU.Core;
using Domain.Translator;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure.Presentation;
using Monry.CAFUSample.Domain.UseCase;
using Monry.CAFUSample.Presentation.Presenter;
using Monry.CAFUSample.Presentation.View.GameResult;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Application.Installer
{
    public class GameResultInstaller : MonoInstaller<GameResultInstaller>
    {
        [SerializeField] private ButtonSend buttonSend;
        private ButtonSend ButtonSend => buttonSend;
        [SerializeField] private ButtonReplay buttonReplay;
        private ButtonReplay ButtonReplay => buttonReplay;
        [SerializeField] private ButtonFinish buttonFinish;
        private ButtonFinish ButtonFinish => buttonFinish;
        [SerializeField] private Score score;
        private Score Score => score;
        [SerializeField] private PlayerName playerName;
        private PlayerName PlayerName => playerName;
        [SerializeField] private PlayedAt playedAt;
        private PlayedAt PlayedAt => playedAt;

        public override void InstallBindings()
        {
            // Entities
            Container.BindIFactory<int, string, IResultEntity>().To<ResultEntity>();

            // UseCases
            Container.BindInterfacesTo<ResultUseCase>().AsCached();

            // Translators
            Container.Bind<ITranslator<IResultEntity, IResult>>().To<ResultTranslator>().AsCached();

            // Presenters
            Container.BindInterfacesTo<GameResultPresenter>().AsCached();

            // Views
            Container.Bind<IButtonTrigger>().WithId(Constant.InjectId.ButtonSend).FromInstance(ButtonSend).AsCached();
            Container.Bind<IButtonTrigger>().WithId(Constant.InjectId.ButtonReplay).FromInstance(ButtonReplay).AsCached();
            Container.Bind<IButtonTrigger>().WithId(Constant.InjectId.ButtonFinish).FromInstance(ButtonFinish).AsCached();
            Container.BindInterfacesTo<Score>().FromInstance(Score).AsCached();
            Container.BindInterfacesTo<PlayerName>().FromInstance(PlayerName).AsCached();
            Container.BindInterfacesTo<PlayedAt>().FromInstance(PlayedAt).AsCached();
        }
    }
}