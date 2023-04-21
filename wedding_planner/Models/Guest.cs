namespace wedding_planner.Models;
using System.ComponentModel.DataAnnotations;

public class Guest
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdateddAt { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

}

