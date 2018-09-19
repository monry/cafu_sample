using System.Collections.Generic;
using System.Linq;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Entity
{
    public interface IRankingEntity : IEntity
    {
        IList<IResultEntity> ResultEntityList { get; }
    }

    public class RankingEntity : IRankingEntity
    {
        public IList<IResultEntity> ResultEntityList { get; }

        public RankingEntity(IEnumerable<ResultEntity> resultEntityList)
        {
            ResultEntityList = resultEntityList.Cast<IResultEntity>().ToList();
        }

        public RankingEntity() : this(new List<ResultEntity>())
        {
        }
    }
}