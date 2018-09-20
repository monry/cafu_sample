using System;
using System.Collections.Generic;
using CAFU.Core;
using CAFU.Data.Data.UseCase;
using CAFU.Data.Utility;
using Monry.CAFUSample.Application;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;
using UniRx;
using Zenject;

namespace Monry.CAFUSample.Domain.UseCase
{
    public class ResultUseCase : IUseCase, IInitializable
    {
        [Inject(Id = Constant.InjectId.ResultListFileUri)] private Uri ResultListFileUri { get; }
        [Inject] private IResultListHandler ResultListHandler { get; }
        [InjectOptional] private IResultListClearable ResultListClearable { get; }
        [Inject] private IAsyncCRUDHandler AsyncCRUDHandler { get; }
        [Inject] private ITranslator<IResultListEntity, IDataResultList> DataResultListStructureTranslator { get; }
        [Inject] private ITranslator<IDataResultList, IResultListEntity> ResultListEntityTranslator { get; }
        [Inject] private AsyncSubject<IResultEntity> ResultEntitySubject { get; }
        [Inject] private AsyncSubject<IResultListEntity> RankingEntitySubject { get; }
        [Inject] private IFactory<IEnumerable<IResultEntity>, IResultListEntity> ResultListEntityFactory { get; }

        void IInitializable.Initialize()
        {
            ResultListHandler.LoadAsObservable().Subscribe(_ => Read());
            ResultListHandler.SaveAsObservable().Subscribe(_ => Write());
            ResultListClearable?.ClearAsObservable().Subscribe(_ => Clear());
            ResultEntitySubject.Subscribe(AddResult);
        }

        private async void Read()
        {
            // 存在しない場合、一旦空ファイルを作る
            if (!AsyncCRUDHandler.Exists(ResultListFileUri))
            {
                await AsyncCRUDHandler.CreateAsync(ResultListFileUri, ResultListEntityFactory.Create(new List<IResultEntity>()).ToByteArray());
            }
            var bytes = await AsyncCRUDHandler.ReadAsync(ResultListFileUri);
            RankingEntitySubject.OnNext(ResultListEntityTranslator.Translate(bytes.FromByteArray<DataResultList>()));
            RankingEntitySubject.OnCompleted();
        }

        private async void Write()
        {
            // 念のため ResultListEntity の生成準備を待つ
            await RankingEntitySubject;
            var ranking = DataResultListStructureTranslator.Translate(RankingEntitySubject.Value);
            await AsyncCRUDHandler.UpdateAsync(ResultListFileUri, ranking.ToByteArray());
        }

        private async void Clear()
        {
            await AsyncCRUDHandler.DeleteAsync(ResultListFileUri);
        }

        private async void AddResult(IResultEntity resultEntity)
        {
            await RankingEntitySubject;
            RankingEntitySubject.Value.List.Add(resultEntity);
        }
    }
}