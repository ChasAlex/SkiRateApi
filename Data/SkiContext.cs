using Microsoft.EntityFrameworkCore;
using SkiRateApi.Models;
namespace SkiRateApi.Data
{
    public class SkiContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Skiday> Skiday { get; set; }

        public SkiContext(DbContextOptions<SkiContext> options) : base(options) { }
    }
}
 