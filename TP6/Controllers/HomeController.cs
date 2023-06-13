using Microsoft.AspNetCore.Mvc;

namespace TP6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
