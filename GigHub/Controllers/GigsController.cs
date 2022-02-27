using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers;

public class GigsController : Controller
{
    // GET
    public IActionResult Create()
    {
        return View();
    }
}