namespace HeroWars.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<HeroEntity> Heroes { get; set; }
}
