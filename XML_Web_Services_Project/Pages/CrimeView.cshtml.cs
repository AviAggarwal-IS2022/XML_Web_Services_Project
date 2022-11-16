using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NeighborhoodFriend_CrimeData;
using System.IO;
using XML_Web_Services_Project.Pages;

namespace XML_Web_Services_Project.Pages
{
    public class CrimeViewModel : PageModel
    {
        

        private readonly ILogger<IndexModel> _logger;

        public CrimeViewModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            try
            {
                var task = IndexModel.client.GetAsync("https://data.cincinnati-oh.gov/resource/k59e-2pvf.json");
                HttpResponseMessage result = task.Result;
                List<CrimeData> crimes = new List<CrimeData>();
                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    crimes = CrimeData.FromJson(jsonString);
                    
                }
                ViewData["CrimeDatas"] = crimes;
            }
            
            catch (System.Exception e)
            {
                Console.WriteLine("Error reading Message = {0}", e.Message);
                ViewData["Error"] = e.Message;

            }
            
                
        }
    }
}