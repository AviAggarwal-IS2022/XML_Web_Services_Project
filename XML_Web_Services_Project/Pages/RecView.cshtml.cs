using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RecreationData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace XML_Web_Services_Project.Pages
{
    public class RecViewModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<IndexModel> _logger;

        public RecViewModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            string project = "Neighborhood Friend";            
            List<RecreationData> recreationFacilityList = GetRecreationData();
            ViewData["RecDatas"] = recreationFacilityList;
        }

        public List<RecreationData> GetRecreationData()
        {
            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/vset-45gc.json");
            HttpResponseMessage result = task.Result;
            List<RecreationData> recreationFacilityList = new List<RecreationData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                JSchema RecreationDataSchema = JSchema.Parse(System.IO.File.ReadAllText("recreationschema.json"));
                JArray RecreationDataJsonArray = JArray.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                if (RecreationDataJsonArray.IsValid(RecreationDataSchema, out validationEvents))
                {
                    recreations = RecreationData.FromJson(jsonString);
                }
                else
                {
                    foreach (string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                }
                recreations = RecreationData.FromJson(jsonString);
            }
            return recreationFacilityList;
        }
    }
}