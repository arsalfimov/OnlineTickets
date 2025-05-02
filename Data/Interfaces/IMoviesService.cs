using OnlineTickets.Data.Base;
using OnlineTickets.Data.ViewModels;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Interfaces;

public interface IMoviesService : IEntityBaseRepository<Movie>
{
    Task<Movie> GetMovieByIdAsync(int id);
    Task<MovieDropdownsVm> GetMovieDropdownsValues();
    Task AddMovieAsync(MovieVm data);
    Task UpdateMovieAsync(MovieVm data);
}