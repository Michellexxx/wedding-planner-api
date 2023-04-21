namespace wedding_planner.Models;
using System.ComponentModel.DataAnnotations;

public class Gift
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }

    [Required, StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; } = string.Empty;
}

