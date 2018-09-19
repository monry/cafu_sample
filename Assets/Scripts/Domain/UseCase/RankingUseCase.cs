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
        [Inject] private IResultListHandler ResultListHandler { get; }
        [Inject] private IAsyncRWHandler AsyncRWHandler { get; }
        [Inject] private ITranslator<IResultListEntity, IResultList> RankingStructureTranslator { get; }
        [Inject] private ITranslator<IResultList, IResultListEntity> RankingEntityTranslator { get; }
        [Inject] private AsyncSubject<IResultEntity> ResultEntitySubject { get; }
        [Inject] private AsyncSubject<IResultListEntity> RankingEntitySubject { get; }
        [Inject] private IFactory<IResultListEntity> RankingEntityFactory { get; }

        void IInitializable.Initialize()
        {
            ResultListHandler.LoadAsObservable().Subscribe(_ => Read());
            ResultListHandler.SaveAsObservable().Subscribe(_ => Write());
            ResultEntitySubject.Subscribe(AddResult);
        }

        private async void Read()
        {
            try
            {
                var bytes = await AsyncRWHandler.ReadAsync(RankingFileUri);
                RankingEntitySubject.OnNext(RankingEntityTranslator.Translate(bytes.FromByteArray<ResultList>()));
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
            // 念のため ResultListEntity の生成準備を待つ
            await RankingEntitySubject;
            var ranking = RankingStructureTranslator.Translate(RankingEntitySubject.Value);
            await AsyncRWHandler.WriteAsync(RankingFileUri, ranking.ToByteArray());
        }

        private async void AddResult(IResultEntity resultEntity)
        {
            await RankingEntitySubject;
            RankingEntitySubject.Value.List.Add(resultEntity);
        }
    }
}