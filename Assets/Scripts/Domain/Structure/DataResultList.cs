using System;
using System.Collections.Generic;
using System.Linq;
using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IDataResultList : IStructure
    {
        IEnumerable<IDataResult> List { get; }

    }

    [Serializable]
    public struct DataResultList : IDataResultList
    {
        [SerializeField] private List<DataResult> list;

        public IEnumerable<IDataResult> List => list.Cast<IDataResult>();

        public DataResultList(IEnumerable<IDataResult> list)
        {
            this.list = list.Cast<DataResult>().ToList();
        }
    }
}