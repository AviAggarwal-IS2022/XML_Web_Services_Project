using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_CrimeData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace XML_Web_Services_Project.Pages
{
    public class CrimeViewModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<IndexModel> _logger;

        public CrimeViewModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string project = "Neighborhood Friend";

            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/k59e-2pvf.json");
            HttpResponseMessage result = task.Result;
            List<CrimeData> crimes = new List<CrimeData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                JSchema CrimeDataSchema = JSchema.Parse(System.IO.File.ReadAllText("crimeschema.json"));
                JArray CrimeDataJsonArray = JArray.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                if (CrimeDataJsonArray.IsValid(CrimeDataSchema, out validationEvents))
                {
                    crimes = CrimeData.FromJson(jsonString);
                }
                else
                {
                    foreach (string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                }
                crimes = CrimeData.FromJson(jsonString);
            }

            ViewData["CrimeDatas"] = crimes;
        }
    }
}