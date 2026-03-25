using Microsoft.EntityFrameworkCore;
using StarWarsDatabase.Entities;

namespace StarWarsDatabase
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<CharacterEntity> Characters { get; set; }
    }
}
