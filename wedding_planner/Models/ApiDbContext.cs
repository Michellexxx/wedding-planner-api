using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Models;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    public DbSet<Guest> Guest { get; set; } = null!;
    public DbSet<Gift> Gift { get; set; } = null!;
}
