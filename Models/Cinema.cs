using System.ComponentModel.DataAnnotations;
using OnlineTickets.Data.Base;

namespace OnlineTickets.Models;

public class Cinema : IEntityBase
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Cinema Logo")]
    [Required(ErrorMessage = "Cinema logo is required")]
    public string Logo { get; set; }
    
    [Display(Name = "Cinema Name")]
    [Required(ErrorMessage = "Cinema name is required")]
    public string Name { get; set; }
    
    [Display(Name = "Cinema Description")]
    [Required(ErrorMessage = "Description description is required")]
    public string Description { get; set; }
    
    //Relationships
    public List<Movie> Movies { get; set; } = [];
}