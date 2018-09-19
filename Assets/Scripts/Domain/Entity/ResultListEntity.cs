using System.Collections.Generic;
using System.Linq;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Entity
{
    public interface IResultListEntity : IEntity
    {
        IList<IResultEntity> List { get; }
    }

    public class ResultListEntity : IResultListEntity
    {
        public IList<IResultEntity> List { get; }

        public ResultListEntity(IEnumerable<ResultEntity> list)
        {
            List = list.Cast<IResultEntity>().ToList();
        }

        public ResultListEntity() : this(new List<ResultEntity>())
        {
        }
    }
}