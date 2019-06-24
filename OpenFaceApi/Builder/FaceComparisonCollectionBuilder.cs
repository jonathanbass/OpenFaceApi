using System;
using System.Collections.Generic;
using System.Linq;
using OpenFaceApi.DTO;

namespace OpenFaceApi.Builder
{
    public class FaceComparisonCollectionBuilder : IFaceComparisonCollectionBuilder
    {
        private readonly IFaceComparisonBuilder _faceComparisonBuilder;

        public FaceComparisonCollectionBuilder(IFaceComparisonBuilder faceComparisonBuilder)
        {
            _faceComparisonBuilder = faceComparisonBuilder;
        }

        public IEnumerable<FaceComparison> Build(string outputText)
        {
            var textInputs = outputText.Split("Comparing ")
                .Where(line => line != string.Empty && !line.Contains(@"C:\"));

            return textInputs.Select(textInput => _faceComparisonBuilder.Build(textInput)).ToList();
        }
    }
}
