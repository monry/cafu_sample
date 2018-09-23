using CAFU.Core;

namespace Monry.CAFUSample.Domain.Structure
{
    public interface IRanking : IStructure
    {
        int Rank { get; }
        IPresentationResult PresentationResult { get; }
    }

    public struct Ranking : IRanking
    {
        public Ranking(int rank, IPresentationResult presentationResult)
        {
            Rank = rank;
            PresentationResult = presentationResult;
        }

        public int Rank { get; }
        public IPresentationResult PresentationResult { get; }
    }
}