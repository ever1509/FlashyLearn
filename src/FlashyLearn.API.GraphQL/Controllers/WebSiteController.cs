using Microsoft.AspNetCore.Mvc;

namespace FlashyLearn.API.GraphQL.Controllers;

public class WebSiteController : Controller
{
    public IActionResult Index()
    {
        return PhysicalFile(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"),
            "text/HTML");
    }
}