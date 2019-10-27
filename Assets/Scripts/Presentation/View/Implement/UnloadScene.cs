using CAFUSample.Application.ValueObject.Master;
using UniFlow;
using UniFlow.Connector.Controller;
using UnityEngine;

namespace CAFUSample.Presentation.View.Implement
{
    [AddComponentMenu("UniFlow/Controller/UnloadScene (Enum)", (int) ConnectorType.LoadScene)]
    public class UnloadScene : UnloadSceneEnumBase<SceneName>
    {
    }
}