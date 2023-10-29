using Cinema_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cinema_api.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
