using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeighborhoodFriend_RecreationData;


namespace XML_Web_Services_Project.Pages
{
    public class RecreationModel : PageModel
    {
        private readonly ILogger<RecreationModel> _logger;
        static readonly HttpClient client = new HttpClient();

        public bool SearchCompleted { get; set; }
        public string Query { get; set; }
        public RecreationData restaurants;
        private List<RecreationData> recreationsList;

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
        public RecreationModel(ILogger<RecreationModel> logger)
        {
            _logger = logger;
        }
        public async Task OnGetAsync(string query)
        {
            Query = query;

            if (!string.IsNullOrEmpty(query))
            {
                SearchCompleted = true;
                String s1 = "https://data.cincinnati-oh.gov/resource/vset-45gc.json?zip_code=";

                String f = s1 + query;

                var task = client.GetAsync(f);

                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {

                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string recreationDetails = readString.Result;
                    recreationsList = RecreationData.FromJson(recreationDetails);
                }
            }
            else
            {
                SearchCompleted = false;
            }
            ViewData["RecreationDatas"] = recreationsList;
        }
    }
}