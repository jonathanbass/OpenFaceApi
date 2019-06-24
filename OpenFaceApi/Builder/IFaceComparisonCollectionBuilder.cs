using System.Collections.Generic;
using OpenFaceApi.DTO;

namespace OpenFaceApi.Builder
{
    public interface IFaceComparisonCollectionBuilder
    {
        IEnumerable<FaceComparison> Build(string outputText);
    }
}