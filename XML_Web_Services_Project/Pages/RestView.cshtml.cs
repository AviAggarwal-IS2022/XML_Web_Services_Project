using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RestaurantData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace XML_Web_Services_Project.Pages
{
    public class RestViewModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<IndexModel> _logger;

        public RestViewModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json");
            HttpResponseMessage result = task.Result;
            List<RestaurantData> restaurants = ParseRestaurantData(result);
            ViewData["RestDatas"] = restaurants;
        }
        public List<RestaurantData> ParseRestaurantData(HttpResponseMessage result)
        {
            List<RestaurantData> restaurantsList = new List<RestaurantData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                JSchema RestaurantDataSchema = JSchema.Parse(System.IO.File.ReadAllText("restaurantschema.json"));
                JArray RestaurantDataJsonArray = JArray.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                if (RestaurantDataJsonArray.IsValid(RestaurantDataSchema, out validationEvents))
                {
                    restaurantsList = RestaurantData.FromJson(jsonString);
                }
                else
                {
                    foreach (string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                }

                restaurantsList = RestaurantData.FromJson(jsonString);
            }
            return restaurantsList;
        }
    }
}
