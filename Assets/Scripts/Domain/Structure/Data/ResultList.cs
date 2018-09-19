using System;
using System.Collections.Generic;
using System.Linq;
using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure.Data
{
    public interface IResultList : IStructure
    {
        IEnumerable<IResult> List { get; }

    }

    [Serializable]
    public struct ResultList : IResultList
    {
        [SerializeField] private List<Result> list;

        public IEnumerable<IResult> List => list.Cast<IResult>();

        public ResultList(List<Result> list)
        {
            this.list = list;
        }
    }
}