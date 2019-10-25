using CAFUSample.Application.ValueObject.Transaction;
using UniFlow;
using UniFlow.Connector.ValueProvider;
using UnityEngine;

namespace CAFUSample.Presentation.View.Implement
{
    [AddComponentMenu("UniFlow/Custom/HoleListExtractor", (int) ConnectorType.Custom)]
    public class HoleListExtractor : ListProviderBase<Hole>
    {
    }
}