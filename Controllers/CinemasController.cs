using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;

namespace OnlineTickets.Controllers;

public class CinemasController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;
    
    public async Task<IActionResult> Index()
    {
        var allCinemas = await _context.Cinemas.ToListAsync();
        return View(allCinemas);
    }
}