using System.ComponentModel.DataAnnotations;
using OnlineTickets.Data.Base;

namespace OnlineTickets.Models;

public class Producer : IEntityBase
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile picture is required")]
    public string ProfilePicture { get; set; }
    
    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 chars")]
    public string FullName { get; set; }
    
    [Display(Name = "Biography")]
    [Required(ErrorMessage = "Biography is required")]
    public string Bio { get; set; }
    
    //Relationships
    public List<Movie> Movies { get; set; } = [];
}