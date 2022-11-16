using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RestaurantData;

namespace XML_Web_Services_Project.Pages
{
    public class RestViewModel : PageModel
    {
        /*static readonly HttpClient client = new HttpClient();*/

        private readonly ILogger<IndexModel> _logger;

        public RestViewModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            
            try
            {
                var task = IndexModel.client.GetAsync("https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json");
                HttpResponseMessage result = task.Result;
                List<RestaurantData> restaurants = new List<RestaurantData>();
                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    restaurants = RestaurantData.FromJson(jsonString);
                }

                ViewData["RestDatas"] = restaurants;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error reading Message = {0}", e.Message);
                ViewData["Error"] = e.Message;

            }

        }
    }
}
