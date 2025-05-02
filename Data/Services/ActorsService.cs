using OnlineTickets.Data.Base;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services;

public class ActorsService(AppDbContext context) : EntityBaseRepository<Actor>(context), IActorsService;