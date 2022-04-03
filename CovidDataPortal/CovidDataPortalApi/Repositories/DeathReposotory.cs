using CovidDataPortalApi.Data;
using CovidDataPortalApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CovidDataPortalApi.Repositories
{
    public interface IDeathRepository
    {
        Task<IEnumerable<Models.Domain.Deaths>> getallDeathsAsync();
    }
    public class DeathReposotory : IDeathRepository
    {
        public CovidDataPortalDbContext CovidDataPortalDbContext { get; }
        public DeathReposotory(CovidDataPortalDbContext covidDataPortalDbContext)
        {
            CovidDataPortalDbContext = covidDataPortalDbContext;
        }



        public async Task<IEnumerable<Deaths>> getallDeathsAsync()
        {
            return await CovidDataPortalDbContext.Deaths.ToListAsync();
        }
    }
}
