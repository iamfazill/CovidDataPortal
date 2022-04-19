using AutoMapper;
using CovidDataPortalApi.Models.DTO;
using CovidDataPortalApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidDataPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseClassController : ControllerBase
    {
        public ICaseClassRepository _caseClassRepository { get; }
        private readonly IMapper mapper;

        public CaseClassController(ICaseClassRepository caseClassRepository, IMapper mapper)
        {
            _caseClassRepository = caseClassRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetALlCaseClasses()
        {
            var CaseClasses = await _caseClassRepository.GetCasesClasses();

            if (CaseClasses == null)
            {

                return NotFound();
            }
            var DtoCaseClassea = mapper.Map<List<Models.DTO.CasesClass>>(CaseClasses);


            return Ok(DtoCaseClassea);


        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetSingleCaseClassAsync(int id)
        {
            var singleCaseClass = await _caseClassRepository.GetSingleCaseClassesAsync(id);
            if (singleCaseClass == null)
            {
                return NotFound();
            }

            var DtoSingleCaseClass = mapper.Map<Models.DTO.CasesClass>(singleCaseClass);

            return Ok(DtoSingleCaseClass);
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateCaseClassAsync([FromRoute] int id, [FromBody] UpdateCaseClass updatecasesClass)
        {
            //first convert dto to domain

            var updateCaseClass = new Models.Domain.CasesClass()
            {
                Date = updatecasesClass.Date,
                Contacts = updatecasesClass.Contacts,
                Comorbid = updatecasesClass.Comorbid,
                PrePostProcedural = updatecasesClass.PrePostProcedural,
                Inpatient = updatecasesClass.Inpatient,
                Random = updatecasesClass.Random,
                Traveller = updatecasesClass.Traveller,
                Defence = updatecasesClass.Defence,
                Anc = updatecasesClass.Anc,
                Symptomatic = updatecasesClass.Symptomatic,
                Gsp = updatecasesClass.Gsp,
                Untraced = updatecasesClass.Untraced,
                Reinfection = updatecasesClass.Reinfection,
                TotalDaysCases = updatecasesClass.TotalDaysCases,
                ContactsTraced = updatecasesClass.ContactsTraced

            };


            //update the caseClass using repository

            var updateCaseClasss = await _caseClassRepository.UpdateSingleCaseClassAsync(id, updateCaseClass);

            //if caseclass not found return null

            if (updateCaseClasss == null)
            {
                return NotFound();
            }

            //if found convert domain back to dto


            var DtoUpdatedCaseClass = mapper.Map<Models.Domain.CasesClass>(updateCaseClasss);

            // finally return the dto to the user

            return Ok(DtoUpdatedCaseClass);


        }

       [HttpPost]
        public async Task<IActionResult> AddCaseClassAsync([FromBody] addCaseClass addCaseClass)
        {

            //first convert dto to domain model to interact with database
            var updateCaseClass = new Models.Domain.CasesClass()
            {
                Date = addCaseClass.Date,
                Contacts = addCaseClass.Contacts,
                Comorbid = addCaseClass.Comorbid,
                PrePostProcedural = addCaseClass.PrePostProcedural,
                Inpatient = addCaseClass.Inpatient,
                Random = addCaseClass.Random,
                Traveller = addCaseClass.Traveller,
                Defence = addCaseClass.Defence,
                Anc = addCaseClass.Anc,
                Symptomatic = addCaseClass.Symptomatic,
                Gsp = addCaseClass.Gsp,
                Untraced = addCaseClass.Untraced,
                Reinfection = addCaseClass.Reinfection,
                TotalDaysCases = addCaseClass.TotalDaysCases,
                ContactsTraced = addCaseClass.ContactsTraced

            };

            var DomainupdateCaseClass =  await _caseClassRepository.AddCaseClassAsync(updateCaseClass);

            // then pass details to repository

            var DtoCaseClass = mapper.Map<Models.DTO.CasesClass>(DomainupdateCaseClass);

            // then convert back it to dto to show it to the user

            return CreatedAtAction(nameof(GetALlCaseClasses), new { id = DtoCaseClass.Id }, DtoCaseClass);
            //return Ok(DtoCaseClass);


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCaseClassAsync(int id)
        {
            //first we need to find the death from the data base

            var DeleatedCaseClass= await _caseClassRepository.DeleteCaseClassAsync(id);

            // if not found , we return null
            if (DeleatedCaseClass == null)
            {

                return NotFound();
            }








            //if found we need to save that  death that is returned from the repository and convert it to dto

            var dtoDeleatedCaseClass = mapper.Map<Models.DTO.CasesClass>(DeleatedCaseClass);


            // finally we need to show it to the user 

            return Ok(dtoDeleatedCaseClass);


        }


    }
}
