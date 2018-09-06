using System;
using CAFU.Core;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IMoleActivationStructure : IStructure
    {
        Action Activate { get; }
        Action Deactivate { get; }
    }

    public struct MoleActivationStructure : IMoleActivationStructure
    {
        public Action Activate { get; set; }
        public Action Deactivate { get; set; }
    }
}