// Pages/YourPage.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.IO;

namespace EMS.Pages.Report
{
    public class IndexModel : PageModel
    {
        
        public IActionResult OnPostAsync()
        {
            // Specify the path to your Python script
            string pythonScriptPath = "Pages/Report/script.py";

            // Run the Python script using a process
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"{pythonScriptPath}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            return RedirectToPage("./Index"); // Redirect back to the page
        }
    }
}
