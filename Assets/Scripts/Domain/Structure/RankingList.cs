using System.Collections.Generic;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IRankingList : IStructure
    {
        IEnumerable<IRanking> List { get; }
    }

    public struct RankingList : IRankingList
    {
        public IEnumerable<IRanking> List { get; }

        public RankingList(IEnumerable<IRanking> list)
        {
            List = list;
        }
    }
}