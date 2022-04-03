using Microsoft.EntityFrameworkCore;

namespace CovidDataPortalApi.Data
{
    public class CovidDataPortalDbContext:DbContext
    {
        public CovidDataPortalDbContext(DbContextOptions<CovidDataPortalDbContext> options):base(options)
        {

        }
        public DbSet<Models.Domain.Deaths> Deaths { get; set; }
    }
}
