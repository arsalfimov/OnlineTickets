using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineTickets.Data;
using OnlineTickets.Data.Base;

namespace OnlineTickets.Models;

public class Movie : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public MovieCategory MovieCategory { get; set; }
    
    //Relationships
    public List<ActorMovie> ActorsMovies { get; set; } = [];
    
    public int CinemaId { get; set; }
    [ForeignKey("CinemaId")]
    public Cinema? Cinema { get; set; }
    
    public int ProducerId { get; set; }
    [ForeignKey("ProducerId")]
    public Producer? Producer { get; set; }
}