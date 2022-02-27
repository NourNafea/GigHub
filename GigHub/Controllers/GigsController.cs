using GigHub.Data;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers;

public class GigsController : Controller
{ 
    ApplicationDbContext Db;

    public GigsController(ApplicationDbContext _db)
    {
        Db = _db;
    }
    // GET
    public IActionResult Create()
    {
        var viewModel = new GigFormViewModel
        {
            Genres = Db.Genres.ToList()
        };
        return View(viewModel);
    }
}