using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Models;

namespace OnlineTickets.Controllers;

public class CinemasController(ICinemasService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var allCinemas = await service.GetAllAsync();
        return View(allCinemas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cinemaDetails = await service.GetByIdAsync(id);
        return cinemaDetails == null ? View("NotFound") : View(cinemaDetails);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
    {
        if (!ModelState.IsValid) return View(cinema);

        await service.AddAsync(cinema);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var cinemaToEdit = await service.GetByIdAsync(id);
        
        if (cinemaToEdit == null) return View("NotFound");
        return View(cinemaToEdit);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }

        await service.UpdateAsync(id, cinema);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var cinemaToDelete = await service.GetByIdAsync(id);
        if (cinemaToDelete == null) return View("NotFound");
        return View(cinemaToDelete);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cinemaToDelete = await service.GetByIdAsync(id);
        if (cinemaToDelete == null) return View("NotFound");
        
        await service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}