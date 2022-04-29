using CovidDataPortalApi.Data;
using CovidDataPortalApi.Helpers.paging;
using CovidDataPortalApi.Models;
using CovidDataPortalApi.Models.CommonModels;
using CovidDataPortalApi.Models.Domain;

using Microsoft.EntityFrameworkCore;

namespace CovidDataPortalApi.Repositories
{
    public interface IDeathRepository
    {
        ResponseModel GetallDeathsAsync(string searchString, string sortColumn, string sortOrder, int pageNo, int pageSize);
        Task<Deaths> GetSingleDeathAsync(int id);

        Task<Deaths> AddDeathAsync(Deaths death);

        Task<Deaths> DeleteDeathAsync(int id);

        Task<Deaths> UpdateDeathAsync(int id, Deaths death);

    }



    public class DeathReposotory : IDeathRepository
    {
        public CovidDataPortalDbContext CovidDataPortalDbContext { get; }
        public DeathReposotory(CovidDataPortalDbContext covidDataPortalDbContext)
        {
            CovidDataPortalDbContext = covidDataPortalDbContext;
        }



        public ResponseModel GetallDeathsAsync(string searchString, string sortColumn, string sortOrder, int pageNo, int pageSize)
        {
            ResponseModel res = new ResponseModel();
            int skip = (pageNo - 1) * pageSize;
            var pages = new PaginationModel<Deaths>();

            try

            {
                var data = CovidDataPortalDbContext.Deaths
                    .Where(x => string.IsNullOrEmpty(searchString) ||
                  x.Name.Contains(searchString) ||
                  x.Address.Contains(searchString) ||
                  x.Block.Contains(searchString) ||
                  x.ContactNumber.Contains(searchString));


                switch ((sortColumn + "").ToLower())
                {
                    case "name":
                        data = (sortOrder + "").ToLower() == "desc" ? data.OrderByDescending(c => c.Name) : data.OrderBy(c => c.Name);
                        break;

                    case "block":
                        data = (sortOrder + "").ToLower() == "desc" ? data.OrderByDescending(c => c.Block) : data.OrderBy(c => c.Block);
                        break;
                    case "age":
                        data = (sortOrder + "").ToLower() == "desc" ? data.OrderByDescending(c => c.Age) : data.OrderBy(c => c.Age);
                        break;
                    case "address":
                        data = (sortOrder + "").ToLower() == "desc" ? data.OrderByDescending(c => c.Address) : data.OrderBy(c => c.Address);
                        break;

                    default:
                        data = data;
                        break;
                }
                pages.Records = data
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();

                pages.RecordCount = new RecordCountModel();
                pages.RecordCount.Count = CovidDataPortalDbContext.Deaths.Count();
                res.Message = "All users Fetched Successfully";
                res.Data = pages;


            }

            catch (Exception ex)
            {
                res.Success = false;
                res.ErrorMessage = ex.Message;

            }

            return res;

            //new code




            ////sorting
            //var allDeaths = await CovidDataPortalDbContext.Deaths.ToListAsync();

            //if(!string.IsNullOrEmpty(sortBy))
            //{
            //    switch(sortBy)
            //    {
            //        case "name_desc":
            //            allDeaths = allDeaths.OrderByDescending(n => n.Name).ToList();
            //            break;
            //        case "name_aesc":
            //            allDeaths = allDeaths.OrderBy(n => n.Name).ToList();
            //            break;
            //        default:
            //            break;

            //    }


            //}
            ////searching
            //if(!string.IsNullOrEmpty(searchString))
            //{

            //    allDeaths = allDeaths.Where(n => n.Name.Contains(searchString,StringComparison.CurrentCultureIgnoreCase)).ToList();

            //}


            //pagination

            //int pagesize = 10;

            //allDeaths = paginatedList<Deaths>.Create(allDeaths.AsQueryable(), pageNo ?? 1, pagesize);

            //return allDeaths;

            //var pagesize = 10f;
            //var pageCount = Math.Ceiling(CovidDataPortalDbContext.Deaths.Count() / pagesize);
            //var skip = (pageNo - 1) * (int)pagesize;
            //var take = (int)pagesize;


            //var resultDeaths = await CovidDataPortalDbContext.Deaths
            //    .Skip(skip)
            //    .Take(take)
            //    .ToListAsync();

            //return resultDeaths;



            //var deaths = new deathResource();

            //deaths.allDeathResponses = resultDeaths;
            //deaths.currentPage = pageNo;
            //deaths.pages=(int)pageCount;
            //return deaths;


        }

        public async Task<Deaths> GetSingleDeathAsync(int id)
        {
            var singledeath = await CovidDataPortalDbContext.Deaths.FirstOrDefaultAsync(x => x.Id == id);
            return (singledeath);
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


    }
}
