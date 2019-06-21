using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace OpenFaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenFaceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string images)
        {
            var result = new List<string> {$"Scanning for images in images/examples/{images}"};

            var process = new Process();
            var startinfo = new ProcessStartInfo("run_openface.bat")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                Arguments = images
            };

            process.StartInfo = startinfo;
            
            process.Start();
            process.WaitForExit();

            var outputText = process.StandardOutput.ReadToEnd();
            var outputLines = SplitActualOutputLines(outputText);

            result.AddRange(outputLines);

            return result;
        }

        private static IEnumerable<string> SplitActualOutputLines(string text)
        {
            return text.Split(Environment.NewLine)
                .Where(line => line != string.Empty && !line.StartsWith(@"C:\"));
        }
    }
}
