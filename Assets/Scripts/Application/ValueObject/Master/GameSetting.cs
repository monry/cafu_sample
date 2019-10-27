using UnityEngine;

namespace CAFUSample.Application.ValueObject.Master
{
    [CreateAssetMenu(menuName = "ValueObject/CAFUSample/Master/GameSetting", fileName = "GameSetting")]
    public class GameSetting : ScriptableObject
    {
        [SerializeField] private int holeAmount = default;
        [SerializeField] private float durationSeconds = default;
        [SerializeField] private Vector2 holePositionRangeX = default;
        [SerializeField] private Vector2 holePositionRangeY = default;

        public int HoleAmount => holeAmount;
        public float DurationSeconds => durationSeconds;
        public Vector2 HolePositionRangeX => holePositionRangeX;
        public Vector2 HolePositionRangeY => holePositionRangeY;
    }
}