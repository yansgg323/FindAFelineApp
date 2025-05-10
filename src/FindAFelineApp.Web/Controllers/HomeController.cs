using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FindAFelineApp.Web.Models;
using FindAFelineApp.Services.Abstractions;

namespace FindAFelineApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICatService _catService;
    public HomeController(ILogger<HomeController> logger, ICatService catService)
    {
        _logger = logger;
        _catService = catService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        ViewBag.Cats = await _catService.GetFeaturedAsync(5);
        return View();
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
