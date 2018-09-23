using System;
using CAFU.Scene.Domain.Structure;
using Monry.CAFUSample.Application.Enumerate;
using UnityEngine;

namespace Monry.CAFUSample.Domain.Structure
{
    [Serializable]
    public class SceneStrategy : SceneStrategy<SceneName>
    {
    }

    [CreateAssetMenu(fileName = "SceneStrategyList", menuName = "Structures/Scene Strategy List")]
    public class SceneStrategyList : PlaceholderSceneStrategyList<SceneName, SceneStrategy>
    {
    }
}