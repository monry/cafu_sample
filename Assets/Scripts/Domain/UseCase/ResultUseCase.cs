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
        [Inject] private AsyncSubject<IResultEntity> ResultEntitySubject { get; }

        void IInitializable.Initialize()
        {
            ResultEntitySubject
                .OnNext(
                    ResultEntityFactory
                        .Create(
                            ScoreEntity.Current.Value,
                            PlayerPrefs.GetString(Constant.PlayerPrefsKey.LastPlayerName, string.Empty)
                        )
                );
            ResultEntitySubject.OnCompleted();
            GameResultHandler.RenderResult(ResultTranslator.Translate(ResultEntitySubject.Value));
            GameResultHandler.UpdatePlayerNameAsObservable().Subscribe(ResultEntitySubject.Value.UpdatePlayerName);
            UnityEngine.Debug.Log("ResultUseCase.Initialize()");
        }
    }
}