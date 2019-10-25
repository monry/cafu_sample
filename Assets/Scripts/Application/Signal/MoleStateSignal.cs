using CAFUSample.Application.ValueObject.Master;
using UniFlow;
using UniFlow.Connector;
using UniFlow.Signal;
using UnityEngine;

namespace CAFUSample.Application.Signal
{
    public class MoleStateSignal : EnumSignalBase<MoleStateSignal, MoleState>
    {
    }

    [AddComponentMenu("UniFlow/Custom/SignalPublisher/MoleStateSignalPublisher", (int) ConnectorType.SignalPublisher)]
    public class MoleStateSignalPublisher : SignalPublisherWithParameterBase<MoleStateSignal, MoleState>
    {
    }

    [AddComponentMenu("UniFlow/Custom/SignalReceiver/MoleStateSignalReceiver", (int) ConnectorType.SignalReceiver)]
    public class MoleStateSignalReceiver : SignalReceiverWithParameterBase<MoleStateSignal, MoleState>
    {
    }
}