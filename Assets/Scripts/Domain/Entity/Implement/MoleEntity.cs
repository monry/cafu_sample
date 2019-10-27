using CAFUSample.Application.ValueObject.Master;
using CAFUSample.Domain.Entity.Interface.UseCase;
using Zenject;

namespace CAFUSample.Domain.Entity.Implement
{
    public class MoleEntity : IInitializable
    {
        public MoleEntity(MoleMaster moleMaster, IMoleStateHandler moleStateHandler)
        {
            MoleMaster = moleMaster;
            MoleStateHandler = moleStateHandler;
        }

        private MoleMaster MoleMaster { get; }
        private IMoleStateHandler MoleStateHandler { get; }

        void IInitializable.Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}