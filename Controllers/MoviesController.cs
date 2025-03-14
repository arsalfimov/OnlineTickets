using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;

namespace OnlineTickets.Controllers;

public class MoviesController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;
    
    public async Task<IActionResult> Index()
    {
        var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
        return View(allMovies);
    }
}