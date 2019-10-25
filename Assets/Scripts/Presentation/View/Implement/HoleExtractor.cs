using System;
using System.Collections.Generic;
using CAFUSample.Application.ValueObject.Transaction;
using UniFlow;
using UniFlow.Utility;
using UnityEngine;

namespace CAFUSample.Presentation.View.Implement
{
    [AddComponentMenu("UniFlow/Custom/HoleExtractor", (int) ConnectorType.Custom)]
    public class HoleExtractor : ConnectorBase,
        IMessageCollectable,
        IMessageComposable
    {
        [SerializeField] private Hole hole = default;
        private Hole Hole
        {
            get => hole;
            set => hole = value;
        }

        [SerializeField] private HoleCollector holeCollector = new HoleCollector();
        private HoleCollector HoleCollector => holeCollector;

        public override IObservable<Message> OnConnectAsObservable()
        {
            return ObservableFactory.ReturnMessage(this);
        }

        IEnumerable<ICollectableMessageAnnotation> IMessageCollectable.GetMessageCollectableAnnotations() =>
            new []
            {
                CollectableMessageAnnotationFactory.Create(HoleCollector, x => Hole = x, nameof(Hole)),
            };

        IEnumerable<IComposableMessageAnnotation> IMessageComposable.GetMessageComposableAnnotations() =>
            new []
            {
                ComposableMessageAnnotationFactory.Create(() => new Vector3(Hole.Position.x, Hole.Position.y, -1), nameof(Hole.Position)),
            };
    }
}