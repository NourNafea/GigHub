using GigHub.Data;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers;

public class GigsController : Controller
{ 
    ApplicationDbContext Db;

    public GigsController(ApplicationDbContext _db)
    {
        Db = _db;
    }
    
    
    [Authorize]
    public IActionResult Create()
    {
        var viewModel = new GigFormViewModel
        {
            Genres = Db.Genres.ToList()
        };
        return View(viewModel);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create(GigFormViewModel viewModel)
    {
        // var artistId = User.Identity.GetUserId();

        var gig = new Gig
        {
            ArtistId = HttpContext.User.Claims.FirstOrDefault().Value,
            DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
            GenreId = viewModel.Genre,
            Venue = viewModel.Venue
        };
        Db.Gigs.Add(gig);
        Db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

}