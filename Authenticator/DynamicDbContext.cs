using Authenticator.Models;
using Microsoft.EntityFrameworkCore;

namespace Authenticator
{
    public class DynamicDbContext(DbContextOptions<DynamicDbContext> options) : DbContext(options)
    {
        public DbSet<WeatherUser> WeatherUser { get; set; }
        public DbSet<WeatherDetails> WeatherDetails { get; set; }
        public DbSet<CityNames> CityNames { get; set; }
        public DbSet<Notes> Notes { get; set; }
    }
}
