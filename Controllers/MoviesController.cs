using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Data.ViewModels;

namespace OnlineTickets.Controllers;

public class MoviesController(IMoviesService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var allMovies = await service.GetAllAsync(p => p.Cinema);
        return View(allMovies);
    }

    public async Task<IActionResult> Details(int id)
    {
        var movieDetails = await service.GetMovieByIdAsync(id);
        return View(movieDetails);
    }
    
    public async Task<IActionResult> Filter(string searchString)
    {
        var allMovies = await service.GetAllAsync(n => n.Cinema);

        if (string.IsNullOrEmpty(searchString)) return View("Index", allMovies);
        {
            //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
            //return View("Index", filteredResult);

            var filterResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase)
                                                       || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return View("Index", filterResultNew);
        }
    }

    public async Task<IActionResult> Create()
    {
        var movieDropdownsData = await service.GetMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MovieVm movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await service.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
        }

        await service.AddMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movieDetails = await service.GetMovieByIdAsync(id);
        if (movieDetails == null) return View("NotFound");

        var response = new MovieVm()
        {
            Id = movieDetails.Id,
            Name = movieDetails.Name,
            Description = movieDetails.Description,
            Price = movieDetails.Price,
            StartDate = movieDetails.StartDate,
            EndDate = movieDetails.EndDate,
            ImageURL = movieDetails.ImageURL,
            MovieCategory = movieDetails.MovieCategory,
            CinemaId = movieDetails.CinemaId,
            ProducerId = movieDetails.ProducerId,
            ActorIds = movieDetails.ActorsMovies.Select(n => n.ActorId).ToList()
        };

        var movieDropdownsData = await service.GetMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, MovieVm movie)
    {
        if (id != movie.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await service.GetMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(movie);
        }

        await service.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}