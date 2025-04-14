using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CIS411Assignment3.Models;
using System.Text.Json;

namespace CIS411Assignment3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private static readonly HttpClient client = new HttpClient();

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Search(string query)
    {
        //check if the query is null or whitespace
        if (string.IsNullOrWhiteSpace(query))
            return RedirectToAction("Index");

        //construct the API URL based on query
        string apiUrl = $"https://api.artic.edu/api/v1/artworks/search?q={query}&fields=id,title,artist_title,image_id,date_display,thumbnail,medium_display&page=1&limit=30";

        //new Get request with constructed URL
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
        //add a User-Agent to the request
        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

        //send response and await
        var response = await client.SendAsync(request);
        //check if the response is successful
        if (!response.IsSuccessStatusCode)
        {
            //if the request was not successful, return an error message
            //this will display below the search box. comment out the User-Agent and you will get a 403 error (Forbidden)
            ViewBag.Error = $"Could not retrieve artwork. Status code: {response.StatusCode}";
            return View("Index");
        }

        //read the response as a string
        var json = await response.Content.ReadAsStringAsync();
        //deserialize the JSON into an ArtworksResponse object with case-insensitive property names
        var artworksResponse = JsonSerializer.Deserialize<ArtworksResponse>(json, new JsonSerializerOptions
        {
            //default is set to false and was causing the Data property to be null
            PropertyNameCaseInsensitive = true
        });

        //check if the Data property is null or empty
        if (artworksResponse?.Data == null || artworksResponse.Data.Count == 0)
        {
            //if no artwork was found, return an error message
            //this will display below the search box. set PropertyNameCaseInsensitive to false and you will get this error
            ViewBag.Error = "No artwork found with that name.";
            return View("Index");
        }

        var artwork = artworksResponse.Data[0]; // Get the first match
        //return details view with the first match as the model
        return View("Details", artwork);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
