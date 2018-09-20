using CAFU.Core;
using Monry.CAFUSample.Domain.Entity;
using Monry.CAFUSample.Domain.Structure;

namespace Monry.CAFUSample.Domain.Translator
{
    public class MoleTranslator : ITranslator<IMoleEntity, IMole>
    {
        public IMole Translate(IMoleEntity param1)
        {
            // BindIFactory は型パラメータ 0〜6, 10個 という制限あり
            return new Mole(
                    param1.ActivateSubject,
                    param1.DeactivateSubject,
                    param1.ShowSubject,
                    param1.HideSubject,
                    param1.FeintSubject,
                    param1.HitSubject,
                    param1.AttackSubject
                );
        }
    }
}