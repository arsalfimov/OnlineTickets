using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;

namespace OnlineTickets.Controllers;

public class ProducersController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;
    
    public async Task<IActionResult> Index()
    {
        var allProducers = await _context.Producers.ToListAsync();
        return View(allProducers);
    }
}