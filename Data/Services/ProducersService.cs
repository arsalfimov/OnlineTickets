using OnlineTickets.Data.Base;
using OnlineTickets.Data.Interfaces;
using OnlineTickets.Models;

namespace OnlineTickets.Data.Services;

public class ProducersService(AppDbContext context) : EntityBaseRepository<Producer>(context), IProducersService;