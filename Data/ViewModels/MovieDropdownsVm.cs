using OnlineTickets.Models;

namespace OnlineTickets.Data.ViewModels;

public class MovieDropdownsVm
{
    public List<Producer> Producers { get; set; } = [];
    public List<Cinema> Cinemas { get; set; } = [];
    public List<Actor> Actors { get; set; } = [];
}