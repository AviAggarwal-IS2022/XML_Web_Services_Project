using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_CrimeData;
using NeighborhoodFriend_RestaurantData;
using System.Collections.Generic;


namespace XML_Web_Services_Project.Pages
{
    public class CrimeModel : PageModel
    {
        private readonly ILogger<CrimeModel> _logger;
        static readonly HttpClient client = new HttpClient();

        public bool SearchCompleted { get; set; }
        public string Query { get; set; }
        public CrimeData crimes;
        private List<CrimeData> crimesList;

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
        public CrimeModel(ILogger<CrimeModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGetAsync(string query)
        {
            Query = query;

            if (!string.IsNullOrEmpty(query))
            {
                SearchCompleted = true;
                String s1 = "https://data.cincinnati-oh.gov/resource/k59e-2pvf.json?zip=";

                String f = s1 + query;

                var task = client.GetAsync(f);

                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {

                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string crimeDetails = readString.Result;
                    crimesList = CrimeData.FromJson(crimeDetails);
                }
            }
            else
            {
                SearchCompleted = false;
            }
            ViewData["CrimeDatas"] = crimesList;
        }
    }
}