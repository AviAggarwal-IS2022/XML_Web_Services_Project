using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RecreationData;
using NeighborhoodFriend_RestaurantData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace XML_Web_Services_Project.Pages
{
    public class NFFRecRestModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();

        private readonly ILogger<IndexModel> _logger;

        public NFFRecRestModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            List<RestaurantData> restaurants = GetRecreationPlacesData();

            ViewData["RestDatas"] = restaurants;
        }

        private static List<RestaurantData> GetRecreationPlacesData()
        {
            string project = "Neighborhood Friend";

            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json");
            HttpResponseMessage result = task.Result;
            List<RestaurantData> restaurants = new List<RestaurantData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                JSchema RestaurantDataSchema = JSchema.Parse(System.IO.File.ReadAllText("restaurantschema.json"));
                JArray RestaurantDataJsonArray = JArray.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                if (RestaurantDataJsonArray.IsValid(RestaurantDataSchema, out validationEvents))
                {
                    restaurants = RestaurantData.FromJson(jsonString);
                }
                else
                {
                    foreach (string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                }
                restaurants = RestaurantData.FromJson(jsonString);
            }

            Task<HttpResponseMessage> taskRec = client.GetAsync("https://data.cincinnati-oh.gov/resource/vset-45gc.json");
            HttpResponseMessage recResult = taskRec.Result;
            Task<string> recTaskString = recResult.Content.ReadAsStringAsync();
            string recJson = recTaskString.Result;
            List<RecreationData> rec = RecreationData.FromJson(recJson);

            IDictionary<long, RecreationData> recreationPlaces = new Dictionary<long, RecreationData>();
            foreach (RecreationData recreationData in rec)
            {
                recreationPlaces[recreationData.ZipCode] = recreationData;
            }

            List<RestaurantData> combinedRecreationPlaces = new List<RestaurantData>();
            foreach (RestaurantData RestaurantData in restaurants)
            {
                if (recreationPlaces.ContainsKey(RestaurantData.PostalCode))
                {
                    combinedRecreationPlaces.Add(RestaurantData);
                }
            }

            return combinedRecreationPlaces;
        }
    }
}