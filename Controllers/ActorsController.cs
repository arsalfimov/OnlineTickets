using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;

namespace OnlineTickets.Controllers;

public class ActorsController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;
    
    public async Task<IActionResult> Index()
    {
        var allActors = await _context.Actors.ToListAsync();
        return View(allActors);
    }

}

