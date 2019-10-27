using UnityEngine;

namespace CAFUSample.Application.ValueObject.Master
{
    [CreateAssetMenu(menuName = "ValueObject/CAFUSample/Master/MoleMaster", fileName = "MoleMaster")]
    public class MoleMaster : ScriptableObject
    {
        [SerializeField] private MoleType moleType = default;
        [SerializeField] private int hitPoint = default;
        [SerializeField] private Sprite spriteNormal = default;
        [SerializeField] private Sprite spriteHit = default;
        [SerializeField] private Color tintColor = default;
        public MoleType MoleType => moleType;
        public int HitPoint => hitPoint;
        public Sprite SpriteNormal => spriteNormal;
        public Sprite SpriteHit => spriteHit;
        public Color TintColor => tintColor;
    }
}