using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Models;

namespace OnlineTickets.Controllers;

public class ActorsController(IActorsService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var allActors = await service.GetAllAsync();
        return View(allActors);
    }

    public async Task<IActionResult> Details(int id)
    {
        var actorDetails = await service.GetByIdAsync(id);
        return actorDetails == null ? View("NotFound") : View(actorDetails);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePicture,FullName,Bio")] Actor actor)
    {
        if (!ModelState.IsValid) return View(actor);

        await service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var actorToEdit = await service.GetByIdAsync(id);
        
        if (actorToEdit == null) return View("NotFound");
        return View(actorToEdit);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicture,FullName,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await service.UpdateAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var actorToDelete = await service.GetByIdAsync(id);
        if (actorToDelete == null) return View("NotFound");
        return View(actorToDelete);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actorToDelete = await service.GetByIdAsync(id);
        if (actorToDelete == null) return View("NotFound");
        
        await service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}