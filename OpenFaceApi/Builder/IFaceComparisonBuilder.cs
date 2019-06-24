using OpenFaceApi.DTO;

namespace OpenFaceApi.Builder
{
    public interface IFaceComparisonBuilder
    {
        FaceComparison Build(string comparisonResult);
    }
}