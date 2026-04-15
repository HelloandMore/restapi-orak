namespace Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<WatchEntity> Watches { get; set; }
}