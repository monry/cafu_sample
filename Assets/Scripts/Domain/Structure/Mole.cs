using CAFU.Core;
using ExtraUniRx;
using UniRx;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IMole : IStructure
    {
        ISubject<Unit> ActivateSubject { get; }
        ISubject<Unit> DeactivateSubject { get; }
        ITenseSubject ShowSubject { get; }
        ITenseSubject HideSubject { get; }
        ITenseSubject FeintSubject { get; }
        ITenseSubject HitSubject { get; }
        ITenseSubject<int> AttackSubject { get; }
    }

    public struct Mole : IMole
    {
        public Mole(ISubject<Unit> activateSubject, ISubject<Unit> deactivateSubject, ITenseSubject showSubject, ITenseSubject hideSubject, ITenseSubject feintSubject, ITenseSubject hitSubject, ITenseSubject<int> attackSubject)
        {
            ActivateSubject = activateSubject;
            DeactivateSubject = deactivateSubject;
            ShowSubject = showSubject;
            HideSubject = hideSubject;
            FeintSubject = feintSubject;
            HitSubject = hitSubject;
            AttackSubject = attackSubject;
        }

        public ISubject<Unit> ActivateSubject { get; }
        public ISubject<Unit> DeactivateSubject { get; }
        public ITenseSubject ShowSubject { get; }
        public ITenseSubject HideSubject { get; }
        public ITenseSubject FeintSubject { get; }
        public ITenseSubject HitSubject { get; }
        public ITenseSubject<int> AttackSubject { get; }
    }
}