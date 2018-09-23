using System;
using System.Collections.Generic;
using System.Linq;
using CAFU.Core;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IPresentationResultList : IStructure
    {
        IEnumerable<IPresentationResult> List { get; }
    }

    [Serializable]
    public struct PresentationResultList : IPresentationResultList
    {
        public IEnumerable<IPresentationResult> List { get; }

        public PresentationResultList(IEnumerable<IPresentationResult> list)
        {
            List = list;
        }
    }
}