using System.Net.NetworkInformation;
using XML_Web_Services_Project.Pages;
using NeighborhoodFriend_RestaurantData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/ApiExpose", () =>
{
    ApiExposeModel restaurantLists = new ApiExposeModel();
    List<RestaurantData> restaurantsAPICall = new List<RestaurantData>();
    restaurantsAPICall = restaurantLists.apiCall();
    return restaurantsAPICall;
})
.WithName("api");

app.Run();
