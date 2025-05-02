using Microsoft.EntityFrameworkCore;
using OnlineTickets.Data.Base;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Data.ViewModels;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services;

public class MoviesService(AppDbContext context) : EntityBaseRepository<Movie>(context), IMoviesService
{
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movieDetails = await context.Movies
            .Include(c => c.Cinema)
            .Include(p => p.Producer)
            .Include(am => am.ActorsMovies).ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(n => n.Id == id);

        return movieDetails;
    }

    public async Task<MovieDropdownsVm> GetMovieDropdownsValues()
    {
        var response = new MovieDropdownsVm()
        {
            Actors = await context.Actors.OrderBy(n => n.FullName).ToListAsync(),
            Cinemas = await context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
            Producers = await context.Producers.OrderBy(n => n.FullName).ToListAsync()
        };
        return response;
    }

    public async Task AddMovieAsync(MovieVm data)
    {
        var newMovie = new Movie()
        {
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            ImageURL = data.ImageURL,
            CinemaId = data.CinemaId,
            StartDate = data.StartDate,
            EndDate = data.EndDate,
            MovieCategory = data.MovieCategory,
            ProducerId = data.ProducerId
        };
        await context.Movies.AddAsync(newMovie);
        await context.SaveChangesAsync();

        foreach (var actorId in data.ActorIds)
        {
            var actorMovie = new ActorMovie()
            {
                MovieId = newMovie.Id,
                ActorId = actorId
            };
            await context.ActorsMovies.AddAsync(actorMovie);
        }

        await context.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(MovieVm data)
    {
        var dbMovie = await context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
        if (dbMovie != null)
        {
            dbMovie.Name = data.Name;
            dbMovie.Description = data.Description;
            dbMovie.Price = data.Price;
            dbMovie.ImageURL = data.ImageURL;
            dbMovie.CinemaId = data.CinemaId;
            dbMovie.StartDate = data.StartDate;
            dbMovie.EndDate = data.EndDate;
            dbMovie.MovieCategory = data.MovieCategory;
            dbMovie.ProducerId = data.ProducerId;
            await context.SaveChangesAsync();
        }
        
        var existingActorDb = context.ActorsMovies
            .Where(n => n.MovieId == data.Id)
            .ToList();
        context.ActorsMovies.RemoveRange(existingActorDb);
        await context.SaveChangesAsync();
        
        foreach (var newActorMovie in data.ActorIds.Select(actorId => new ActorMovie()
                 {
                     MovieId = data.Id,
                     ActorId = actorId
                 }))
        {
            await context.ActorsMovies.AddAsync(newActorMovie);
        }
        await context.SaveChangesAsync();
    }
}

