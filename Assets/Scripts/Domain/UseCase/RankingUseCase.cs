using System;
using System.IO;
using CAFU.Core;
using CAFU.Data.Data.UseCase;
using CAFU.Data.Utility;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure.Data;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class RankingUseCase : IUseCase, IInitializable
    {
        [Inject(Id = Constant.InjectId.RankingFileUri)] private Uri RankingFileUri { get; }
        [Inject] private IRankingHandler RankingHandler { get; }
        [Inject] private IAsyncRWHandler AsyncRWHandler { get; }
        [Inject] private ITranslator<IRankingEntity, IRanking> RankingStructureTranslator { get; }
        [Inject] private ITranslator<IRanking, IRankingEntity> RankingEntityTranslator { get; }
        [Inject] private AsyncSubject<IResultEntity> ResultEntitySubject { get; }
        [Inject] private AsyncSubject<IRankingEntity> RankingEntitySubject { get; }
        [Inject] private IFactory<IRankingEntity> RankingEntityFactory { get; }

        void IInitializable.Initialize()
        {
            RankingHandler.LoadAsObservable().Subscribe(_ => Read());
            RankingHandler.SaveAsObservable().Subscribe(_ => Write());
            ResultEntitySubject.Subscribe(AddResult);
            UnityEngine.Debug.Log("RankingUseCase.Initialize()");
        }

        private async void Read()
        {
            try
            {
                var bytes = await AsyncRWHandler.ReadAsync(RankingFileUri);
                RankingEntitySubject.OnNext(RankingEntityTranslator.Translate(bytes.FromByteArray<Ranking>()));
                RankingEntitySubject.OnCompleted();
            }
            catch (FileNotFoundException)
            {
                RankingEntitySubject.OnNext(RankingEntityFactory.Create());
                RankingEntitySubject.OnCompleted();
            }
        }

        private async void Write()
        {
            // 念のため RankingEntity の生成準備を待つ
            await RankingEntitySubject;
            var ranking = RankingStructureTranslator.Translate(RankingEntitySubject.Value);
            await AsyncRWHandler.WriteAsync(RankingFileUri, ranking.ToByteArray());
        }

        private async void AddResult(IResultEntity resultEntity)
        {
            await RankingEntitySubject;
            RankingEntitySubject.Value.ResultEntityList.Add(resultEntity);
        }
    }
}