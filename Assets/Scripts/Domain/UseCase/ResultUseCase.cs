using CAFU.Core;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure.Presentation;
using UniRx;
using UnityEngine;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public interface IResultUseCase : IUseCase
    {
    }

    public class ResultUseCase : IResultUseCase,
        IInitializable
    {
        [Inject] private IScoreEntity ScoreEntity { get; }
        [Inject] private IGameResultHandler GameResultHandler { get; }
        [Inject] private IFactory<int, string, IResultEntity> ResultEntityFactory { get; }
        [Inject] private ITranslator<IResultEntity, IResult> ResultTranslator { get; }
        private IResultEntity ResultEntity { get; set; }

        void IInitializable.Initialize()
        {
            ResultEntity = ResultEntityFactory
                .Create(
                    ScoreEntity.Current.Value,
                    PlayerPrefs.GetString(Constant.PlayerPrefsKey.LastPlayerName, string.Empty)
                );
            GameResultHandler.RenderResult(ResultTranslator.Translate(ResultEntity));
            GameResultHandler.UpdatePlayerNameAsObservable().Subscribe(ResultEntity.UpdatePlayerName);
        }
    }
}