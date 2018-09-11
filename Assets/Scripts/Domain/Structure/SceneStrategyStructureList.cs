using System;
using System.Collections.Generic;
using System.Linq;
using Monry.CAFUSample.Application.Enumerate;
using CAFU.Core;
using CAFU.Scene.Domain.Structure;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure
{
    [Serializable]
    public class SceneStrategyStructure : SceneStrategyStructure<SceneName>
    {
    }

    public interface ISceneStrategyStructureList : IStructure
    {
        IReadOnlyDictionary<string, ISceneStrategyStructure> AsDictionary();
    }

    [CreateAssetMenu(fileName = "SceneStrategyStructureList", menuName = "Structures/Scene Strategy Structure List")]
    public class SceneStrategyStructureList : ScriptableObject, ISceneStrategyStructureList
    {
        [SerializeField] private List<SceneStrategyStructure> list;

        private IEnumerable<ISceneStrategyStructure<SceneName>> List => list;

        public IReadOnlyDictionary<string, ISceneStrategyStructure> AsDictionary()
        {
            return List.ToDictionary(x => x.SceneName.ToString(), x => (ISceneStrategyStructure)x);
        }
    }
}