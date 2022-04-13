using CovidDataPortalApi.Data;
using CovidDataPortalApi.Models.Domain;
 
using Microsoft.EntityFrameworkCore;

namespace CovidDataPortalApi.Repositories
{
    public interface IDeathRepository
    {
        Task<List<Deaths>> GetallDeathsAsync( string sortBy, string searchString, int pageNo, int pageSize );
        Task<Deaths> GetSingleDeathAsync(int id);

        Task<Deaths> AddDeathAsync(Deaths death);

        Task<Deaths> DeleteDeathAsync(int id);

        Task<Deaths> UpdateDeathAsync(int id, Deaths death);

        Task<int> GetDeathCountAsync();
    }



    public class DeathReposotory : IDeathRepository
    {
        public CovidDataPortalDbContext CovidDataPortalDbContext { get; }
        public DeathReposotory(CovidDataPortalDbContext covidDataPortalDbContext)
        {
            CovidDataPortalDbContext = covidDataPortalDbContext;
        }



        public async Task<List<Deaths>> GetallDeathsAsync(string sortBy,string searchString, int pageNo, int pageSize)
        {
            //sorting
            var allDeaths = await CovidDataPortalDbContext.Deaths.ToListAsync();

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                        allDeaths = allDeaths.OrderByDescending(n => n.Name).ToList();
                        break;
                    case "name_aesc":
                        allDeaths = allDeaths.OrderBy(n => n.Name).ToList();
                        break;
                    default:
                        break;

                }


            }

            if(!string.IsNullOrEmpty(searchString))
            {

                allDeaths = allDeaths.Where(n => n.Name.Contains(searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();

            }

            return allDeaths;

            //var pagesize = 10f;
            //var pageCount = Math.Ceiling(CovidDataPortalDbContext.Deaths.Count() / pagesize);
            //var skip = (pageNo - 1) * (int)pagesize;
            //var take = (int)pagesize;


            //var resultDeaths= await CovidDataPortalDbContext.Deaths 
            //    .Skip(skip)
            //    .Take(take)
            //    .ToListAsync();


            //var deaths = new deathResource();

            //deaths.allDeathResponses = resultDeaths;
            //deaths.currentPage = pageNo;
            //deaths.pages=(int)pageCount;
            //return deaths;


        }

        public async Task<Deaths> GetSingleDeathAsync(int id)
        {
            var singledeath= await CovidDataPortalDbContext.Deaths.FirstOrDefaultAsync(x => x.Id == id);
            return(singledeath);
        }

        public async Task<Deaths> AddDeathAsync(Deaths death)
        {
            await CovidDataPortalDbContext.Deaths.AddAsync(death);
            await CovidDataPortalDbContext.SaveChangesAsync();
            return death;


        }

        public async Task<Deaths> DeleteDeathAsync(int id)
        {
            var SingleDeath = await CovidDataPortalDbContext.Deaths.FirstOrDefaultAsync(x => x.Id == id);
            if (SingleDeath == null)
            {
                return null;
            }
            //if it is not null, we will delete the death record
            CovidDataPortalDbContext.Deaths.Remove(SingleDeath);
            await CovidDataPortalDbContext.SaveChangesAsync();
            return SingleDeath;
        }

        public async Task<Deaths> UpdateDeathAsync(int id, Deaths death)
        {
            var updatedDeath = await CovidDataPortalDbContext.Deaths.FirstOrDefaultAsync(x => x.Id == id);
            if (updatedDeath == null)
            {
                return null;
            }
            updatedDeath.Name = death.Name;
            updatedDeath.Age = death.Age;
            updatedDeath.Address = death.Address;
            updatedDeath.Gender = death.Gender;
            updatedDeath.ContactNumber = death.ContactNumber;
            updatedDeath.Block = death.Block;
            updatedDeath.District = death.District;
            updatedDeath.DateOfAdmission = death.DateOfAdmission;
            updatedDeath.DateOfAdmission = death.DateOfAdmission;
            updatedDeath.DateOfAdmission = death.DateOfAdmission;
            updatedDeath.SampleCollected = death.SampleCollected;
            updatedDeath.SampleTestedAt = death.SampleTestedAt;
            updatedDeath.UnderlyingCondition = death.UnderlyingCondition;
            updatedDeath.HospitalWhereAdmitted = death.HospitalWhereAdmitted;
            updatedDeath.DateOfDeath = death.DateOfDeath;
            updatedDeath.DaysTestedBeforeDeath = death.DaysTestedBeforeDeath;
            updatedDeath.DaysAdmitted = death.DaysAdmitted;
            updatedDeath.DaysAdmittedInICU = death.DaysAdmittedInICU;
            updatedDeath.DaysInOxygenSupportOrVentillator = death.DaysInOxygenSupportOrVentillator;
            updatedDeath.Remarks = death.Remarks;
            updatedDeath.VaccinationStatus = death.VaccinationStatus;

             CovidDataPortalDbContext.Update(updatedDeath);

             await CovidDataPortalDbContext.SaveChangesAsync();



            return updatedDeath;



        }

        public async Task<int> GetDeathCountAsync()
        {
             return await CovidDataPortalDbContext.Deaths.CountAsync();
        }
    }
}
