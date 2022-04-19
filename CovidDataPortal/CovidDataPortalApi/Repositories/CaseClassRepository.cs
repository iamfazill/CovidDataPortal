using CovidDataPortalApi.Data;
using CovidDataPortalApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CovidDataPortalApi.Repositories
{
    public interface ICaseClassRepository
    {
        Task<List<CasesClass>> GetCasesClasses();

        Task<CasesClass> GetSingleCaseClassesAsync(int id);

        Task<CasesClass> UpdateSingleCaseClassAsync(int id, CasesClass updatecasesClass);

        Task<CasesClass> AddCaseClassAsync(CasesClass AddcasesClass);

        Task<CasesClass> DeleteCaseClassAsync(int id);



    }
    public class CaseClassRepository : ICaseClassRepository
    {
        private readonly CovidDataPortalDbContext _covidDataPortalDbContext;

        public CaseClassRepository(CovidDataPortalDbContext covidDataPortalDbContext)
        {
            _covidDataPortalDbContext = covidDataPortalDbContext;
        }

        public async Task<CasesClass> AddCaseClassAsync(CasesClass AddcasesClass)
        {
            await _covidDataPortalDbContext.casesClass.AddAsync(AddcasesClass);
           await _covidDataPortalDbContext.SaveChangesAsync();
            return AddcasesClass;
        }

        public async Task<CasesClass> DeleteCaseClassAsync(int id)
        {
            var GetDeleatedCaseClass = await _covidDataPortalDbContext.casesClass.FirstOrDefaultAsync(x => x.Id == id);
            if(GetDeleatedCaseClass==null)
            {
                return null;
            }
            _covidDataPortalDbContext.casesClass.Remove(GetDeleatedCaseClass); ;
             await _covidDataPortalDbContext.SaveChangesAsync();
            return GetDeleatedCaseClass;

        }

        public async Task<List<CasesClass>> GetCasesClasses()
        {
            var CaseClasses = await _covidDataPortalDbContext.casesClass.ToListAsync();
            return CaseClasses;
        }

        public async Task<CasesClass> GetSingleCaseClassesAsync(int id)
        {
            var GetSingleCaseClass = await _covidDataPortalDbContext.casesClass.FirstOrDefaultAsync(x => x.Id == id);
            return GetSingleCaseClass;
        }

        public async Task<CasesClass> UpdateSingleCaseClassAsync(int id, CasesClass updatecasesClass)
        {
            var GetSingleCaseClass = await _covidDataPortalDbContext.casesClass.FirstOrDefaultAsync(x => x.Id == id);

            if(GetSingleCaseClass==null)
            {

                return null;
            }



            GetSingleCaseClass.Date = updatecasesClass.Date;
            GetSingleCaseClass.Contacts = updatecasesClass.Contacts;
            GetSingleCaseClass.Comorbid = updatecasesClass.Comorbid;
            GetSingleCaseClass.PrePostProcedural = updatecasesClass.PrePostProcedural;
            GetSingleCaseClass.Inpatient = updatecasesClass.Inpatient;
            GetSingleCaseClass.Random = updatecasesClass.Random;
            GetSingleCaseClass.Traveller = updatecasesClass.Traveller;
            GetSingleCaseClass.Defence = updatecasesClass.Defence;
            GetSingleCaseClass.Anc=updatecasesClass.Anc;
            GetSingleCaseClass.Symptomatic = updatecasesClass.Symptomatic;
            GetSingleCaseClass.Gsp = updatecasesClass.Gsp;
            GetSingleCaseClass.Untraced = updatecasesClass.Untraced;
            GetSingleCaseClass.Reinfection = updatecasesClass.Reinfection;
            GetSingleCaseClass.TotalDaysCases = updatecasesClass.TotalDaysCases;
            GetSingleCaseClass.ContactsTraced = updatecasesClass.ContactsTraced;

            _covidDataPortalDbContext.Update(GetSingleCaseClass);
            await _covidDataPortalDbContext.SaveChangesAsync();
            return updatecasesClass;





        }
    }
}
