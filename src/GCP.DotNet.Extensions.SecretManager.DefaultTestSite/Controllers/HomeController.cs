using GCP.DotNet.Extensions.SecretManager.DefaultTestSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GCP.DotNet.Extensions.SecretManager.DefaultTestSite.Controllers;
public class HomeController(ILogger<HomeController> logger, IConfiguration configuration) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {

        ViewData["ConnectionString"] = configuration["Test:Secret"];
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
