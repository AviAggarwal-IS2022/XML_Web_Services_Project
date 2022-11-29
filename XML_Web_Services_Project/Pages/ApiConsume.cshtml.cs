using ApiConsume;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RestaurantData;
using ApiConsume;

namespace XML_Web_Services_Project.Pages
{
    public class ApiConsumeModel : PageModel
    {
        static readonly HttpClient client = new HttpClient();
        public void OnGet()
        {
            string project = "Neighborhood Friend";

            var task = client.GetAsync("https://is7024-finalproj-movieflex.azurewebsites.net/movieFlex/top250movies");
            HttpResponseMessage result = task.Result;
            ApiConsumption tvshows = new ApiConsumption();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readstring = result.Content.ReadAsStringAsync();
                string jsonString = readstring.Result;
                tvshows = ApiConsumption.FromJson(jsonString);
            }
            ViewData["Tvshows"] = tvshows;
        }
    }
}
