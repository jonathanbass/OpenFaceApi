using System;
using System.Linq;
using OpenFaceApi.DTO;

namespace OpenFaceApi.Builder
{
    public class FaceComparisonBuilder : IFaceComparisonBuilder
    {
        public FaceComparison Build(string comparisonResult)
        {
            var components = comparisonResult.Split(" ");
            var image1 = components.First();

            const int indexOfSecondImage = 2;
            var image2 = components[indexOfSecondImage].Replace(Environment.NewLine, string.Empty);
            var distanceBetweenImages = Convert.ToDecimal(components.Last());

            return new FaceComparison
            {
                Image1 = image1,
                Image2 = image2,
                DistanceBetweenImages = distanceBetweenImages
            };
        }
    }
}
