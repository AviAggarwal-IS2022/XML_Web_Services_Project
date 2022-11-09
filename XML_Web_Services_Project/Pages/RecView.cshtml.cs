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

            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/vset-45gc.json");
            HttpResponseMessage result = task.Result;
            List<RecreationData> recreations = new List<RecreationData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                recreations = RecreationData.FromJson(jsonString);
            }

            ViewData["RecDatas"] = recreations;
        }
    }
}


