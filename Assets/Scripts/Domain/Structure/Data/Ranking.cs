using System;
using System.Collections.Generic;
using System.Linq;
using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure.Data
{
    public interface IRanking : IStructure
    {
        IEnumerable<IResult> ResultList { get; }

    }

    [Serializable]
    public struct Ranking : IRanking
    {
        [SerializeField] private List<Result> resultList;

        public IEnumerable<IResult> ResultList => resultList.Cast<IResult>();

        public Ranking(List<Result> resultList)
        {
            this.resultList = resultList;
        }
    }
}