using CovidDataPortalApi.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CovidDataPortalApi.Data
{
    public class CovidDataPortalDbContext:IdentityDbContext<ApplicationUser>
    {
        public CovidDataPortalDbContext(DbContextOptions<CovidDataPortalDbContext> options):base(options)
        {

        }
        public DbSet<Models.Domain.Deaths> Deaths { get; set; }

        public DbSet<Models.Domain.CasesClass> casesClass { get; set; }
    }
}
