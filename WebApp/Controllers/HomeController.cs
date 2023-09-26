using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApp.Controllers;
public class HomeController : Controller {
    public IActionResult Index() {
        return View();
    }
}
