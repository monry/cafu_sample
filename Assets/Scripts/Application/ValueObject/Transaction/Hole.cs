using System;
using UniFlow;
using UnityEngine;

namespace CAFUSample.Application.ValueObject.Transaction
{
    [Serializable]
    public class Hole
    {
        private Hole()
        {
        }

        public Vector2 Position { get; private set; }

        public static Hole Create(Vector2 position)
        {
            return new Hole
            {
                Position = position,
            };
        }
    }

    [Serializable]
    public class HoleCollector : ValueCollectorBase<Hole>
    {
    }
}