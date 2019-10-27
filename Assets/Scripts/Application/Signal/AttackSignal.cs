using UniFlow;
using UniFlow.Connector;
using UniFlow.Signal;
using UnityEngine;

namespace CAFUSample.Application.Signal
{
    [CreateAssetMenu(menuName = "UniFlow/Signal/CAFUSample/AttackSignal", fileName = "AttackSignal")]
    public class AttackSignal : ScriptableObjectSignalBase<AttackSignal>
    {
    }

    [AddComponentMenu("UniFlow/Custom/SignalPublisher/AttackSignalPublisher", (int) ConnectorType.SignalPublisher)]
    public class AttackSignalPublisher : SignalPublisherBase<AttackSignal>
    {
    }

    [AddComponentMenu("UniFlow/Custom/SignalReceiver/AttackSignalReceiver", (int) ConnectorType.SignalReceiver)]
    public class AttackSignalReceiver : SignalReceiverBase<AttackSignal>
    {
    }
}