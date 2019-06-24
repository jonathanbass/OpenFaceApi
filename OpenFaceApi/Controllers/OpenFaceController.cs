using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenFaceApi.Builder;
using OpenFaceApi.DTO;

namespace OpenFaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenFaceController : ControllerBase
    {
        private readonly IFaceComparisonCollectionBuilder _faceComparisonCollectionBuilder;

        public OpenFaceController(IFaceComparisonCollectionBuilder faceComparisonCollectionBuilder)
        {
            _faceComparisonCollectionBuilder = faceComparisonCollectionBuilder;
        }

        [HttpGet]
        public ActionResult<FaceComparisonResponse> Get(string searchTerm)
        {
            var process = new Process();
            var startinfo = new ProcessStartInfo("run_openface.bat")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                Arguments = searchTerm
            };

            process.StartInfo = startinfo;

            process.Start();
            process.WaitForExit();

            var outputText = process.StandardOutput.ReadToEnd();
            var result = new FaceComparisonResponse
            {
                SearchTerm = $"Scanning for images in images/examples/{searchTerm}",
                FaceComparisons = _faceComparisonCollectionBuilder.Build(outputText)
            };

            return result;
        }
    }
}
