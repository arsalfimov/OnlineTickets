using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Models;

namespace OnlineTickets.Controllers;

public class ProducersController(IProducersService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var allProducers = await service.GetAllAsync();
        return View(allProducers);
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var producerDetails = await service.GetByIdAsync(id);
        return producerDetails == null ? View("NotFound") : View(producerDetails);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("ProfilePicture,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid) return View(producer);

        await service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var producer = await service.GetByIdAsync(id);
        return producer == null ? View("NotFound") : View(producer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicture,FullName,Bio")] Producer producer)
    {
        if (!ModelState.IsValid || id != producer.Id) return View(producer);

        await service.UpdateAsync(id, producer);
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var producer = await service.GetByIdAsync(id);
        return producer == null ? View("NotFound") : View(producer);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producer = await service.GetByIdAsync(id);
        if (producer == null) return View("NotFound");

        await service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}