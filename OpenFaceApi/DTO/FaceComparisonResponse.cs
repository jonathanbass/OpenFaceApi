using System.Collections.Generic;

namespace OpenFaceApi.DTO
{
    public class FaceComparisonResponse
    {
        public string SearchTerm { get; set; }
        public IEnumerable<FaceComparison> FaceComparisons { get; set; }
    }

    public class FaceComparison
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public decimal DistanceBetweenImages { get; set; }
    }
}
