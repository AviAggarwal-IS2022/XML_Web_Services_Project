using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RecreationData;

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

            var config = new ConfigurationBuilder()
                    .AddUserSecrets<Program>()
                    .Build();



            string apiKey = config["apikey"];
            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/" + apiKey + ".json");
            HttpResponseMessage result = task.Result;
            List<RecreationData> recreationslist = new List<RecreationData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                recreationslist = RecreationData.FromJson(jsonString);
            }

            ViewData["RecDatas"] = recreationslist;
        }
    }
}


