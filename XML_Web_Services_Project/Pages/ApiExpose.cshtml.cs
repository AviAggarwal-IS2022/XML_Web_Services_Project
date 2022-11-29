using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RestaurantData;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace XML_Web_Services_Project.Pages
{
    public class ApiExposeModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            /*  string project = "Neighborhood Friend";

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
  */
            ViewData["RestDatas"] = apiCall();
        }

        public List<RestaurantData> apiCall()
        {
            string project = "Neighborhood Friend";

            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json");
            HttpResponseMessage result = task.Result;
            List<RestaurantData> restaurantsAPICall = new List<RestaurantData>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                JSchema RestaurantDataSchema = JSchema.Parse(System.IO.File.ReadAllText("restaurantschema.json"));
                JArray RestaurantDataJsonArray = JArray.Parse(jsonString);
                IList<string> validationEvents = new List<string>();
                if (RestaurantDataJsonArray.IsValid(RestaurantDataSchema, out validationEvents))
                {
                    restaurantsAPICall = RestaurantData.FromJson(jsonString);
                }
                else
                {
                    foreach (string evt in validationEvents)
                    {
                        Console.WriteLine(evt);
                    }
                }

                restaurantsAPICall = RestaurantData.FromJson(jsonString);
            }
            return restaurantsAPICall;
        }
    }
}
