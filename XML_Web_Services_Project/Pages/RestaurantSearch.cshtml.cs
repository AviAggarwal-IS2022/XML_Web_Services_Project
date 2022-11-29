using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RestaurantData;
using System.Collections.Generic;

namespace XML_Web_Services_Project.Pages
{
    public class RestaurantModel : PageModel
    {
        private readonly ILogger<RestaurantModel> _logger;
        static readonly HttpClient client = new HttpClient();

        public bool SearchCompleted { get; set; }
        public string Query { get; set; }
        public RestaurantData restaurants;
        private List<RestaurantData> restaurantsList;

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
        public RestaurantModel(ILogger<RestaurantModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGetAsync(string query)
        {
            Query = query;

            if (!string.IsNullOrEmpty(query))
            {
                SearchCompleted = true;
                String s1 = "https://data.cincinnati-oh.gov/resource/rg6p-b3h3.json?postal_code=";

                String f = s1 + query;

                var task = client.GetAsync(f);

                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {

                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string restuarantDetails = readString.Result;
                    restaurantsList = RestaurantData.FromJson(restuarantDetails);
                }
            }
            else
            {
                SearchCompleted = false;
            }
            ViewData["RestDatas"] = restaurantsList;
        }
    }
}