using AutoMapper;
using CovidDataPortalApi.Models.Domain;
using CovidDataPortalApi.Models.DTO;
using CovidDataPortalApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CovidDataPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeathsController : ControllerBase
    {
        public IDeathRepository DeathRepository { get; }
        private readonly IMapper Mapper;

        public DeathsController(IDeathRepository deathRepository, IMapper mapper)
        {
            DeathRepository = deathRepository;
            Mapper = mapper;
        }



        [HttpGet]
        [ActionName("GetAllDeaths")]
        public async Task<IActionResult> GetAllDeaths(string? sortBy ,string? searchString ,int pageNo = 1, int pageSize = 10)
        {



            var deaths = await DeathRepository.GetallDeathsAsync(sortBy, searchString,pageNo, pageSize);

            //var ResponceDeath = new deathResource 
            //{
            //  allDeathResponses = deaths.allDeathResponses,
            // currentPage = deaths.currentPage,
            // pages = deaths.pages
            //};



            
           




            //var DeathsDTO = Mapper.Map<List<Models.DTO.Deaths>>(deaths);

            return Ok(deaths);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetSingleDeathAsync(int id)
    {
        var singleDeath = await DeathRepository.GetSingleDeathAsync(id);
        if (singleDeath == null)
        {
            return NotFound();
        }


        var singleDeathDTO = Mapper.Map<Models.DTO.Deaths>(singleDeath);

        return Ok(singleDeathDTO);
    }

    [HttpPost]
    public async Task<IActionResult> AddSingleDeathAsync(AddDeathRequest addDeathRequest)
    {
        //first convert  request(dto) to domain model so to interact with the database

        var death = new Models.Domain.Deaths()
        {
            Name = addDeathRequest.Name,
            Age = addDeathRequest.Age,
            Address = addDeathRequest.Address,
            Gender = addDeathRequest.Gender,
            ContactNumber = addDeathRequest.ContactNumber,
            Block = addDeathRequest.Block,
            District = addDeathRequest.District,
            DateOfAdmission = addDeathRequest.DateOfAdmission,
            SampleCollected = addDeathRequest.SampleCollected,
            SampleTestedAt = addDeathRequest.SampleTestedAt,
            UnderlyingCondition = addDeathRequest.UnderlyingCondition,
            HospitalWhereAdmitted = addDeathRequest.HospitalWhereAdmitted,
            DateOfDeath = addDeathRequest.DateOfDeath,
            DaysTestedBeforeDeath = addDeathRequest.DaysTestedBeforeDeath,
            DaysAdmitted = addDeathRequest.DaysAdmitted,
            DaysAdmittedInICU = addDeathRequest.DaysAdmittedInICU,
            DaysInOxygenSupportOrVentillator = addDeathRequest.DaysInOxygenSupportOrVentillator,
            Remarks = addDeathRequest.Remarks,
            VaccinationStatus = addDeathRequest.VaccinationStatus


        };


        //then pass details to repository
        var region = await DeathRepository.AddDeathAsync(death);


        // then convert data back to dto and show it to the user

        var responceDeath = Mapper.Map<Models.DTO.Deaths>(region);

        return CreatedAtAction(nameof(GetAllDeaths), new { id = responceDeath.Id }, responceDeath);


    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteSigleDeathAsync(int id)
    {
        //step 1: We need to found a Death from the database
        var DeleatedDeath = await DeathRepository.DeleteDeathAsync(id);

        //step 2: If not found, we need to return not found

        if (DeleatedDeath == null)
        {

            return NotFound();
        }

        //step 3: if found , we need to return that deleated death by converting it to a DTO model
        var DeleatedDeathDTO = Mapper.Map<Models.DTO.Deaths>(DeleatedDeath);


        //step 4: finally give responce to the client
        return Ok(DeleatedDeathDTO);

    }


    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateDeathAsync([FromRoute] int id, [FromBody] UpdateDeathRequest updateDeathRequest)
    {
        //step 1: convert DTO to domain model

        var updateDeath = new Models.Domain.Deaths()
        {
            Name = updateDeathRequest.Name,
            Age = updateDeathRequest.Age,
            Address = updateDeathRequest.Address,
            Gender = updateDeathRequest.Gender,
            ContactNumber = updateDeathRequest.ContactNumber,
            Block = updateDeathRequest.Block,
            District = updateDeathRequest.District,
            DateOfAdmission = updateDeathRequest.DateOfAdmission,
            SampleCollected = updateDeathRequest.SampleCollected,
            SampleTestedAt = updateDeathRequest.SampleTestedAt,
            UnderlyingCondition = updateDeathRequest.UnderlyingCondition,
            HospitalWhereAdmitted = updateDeathRequest.HospitalWhereAdmitted,
            DateOfDeath = updateDeathRequest.DateOfDeath,
            DaysTestedBeforeDeath = updateDeathRequest.DaysTestedBeforeDeath,
            DaysAdmitted = updateDeathRequest.DaysAdmitted,
            DaysAdmittedInICU = updateDeathRequest.DaysAdmittedInICU,
            DaysInOxygenSupportOrVentillator = updateDeathRequest.DaysInOxygenSupportOrVentillator,
            Remarks = updateDeathRequest.Remarks,
            VaccinationStatus = updateDeathRequest.VaccinationStatus


        };


        //step 2: update the death using repository
        updateDeath = await DeathRepository.UpdateDeathAsync(id, updateDeath);

        //step 3:if not found , return not found
        if (updateDeath == null)
        {
            return NotFound();
        }


        // step 4: if found , convert Domain to back to DTO model
        var UpdatedDeathDTO = Mapper.Map<Models.Domain.Deaths>(updateDeath);

        //step 5: finally return OK responce
        return Ok(UpdatedDeathDTO);

    }

    //[HttpGet]
    //[Route("count")]
    //public async Task<IActionResult> GetDeathCountAsync()
    //{
    //    var count = await DeathRepository.GetDeathCountAsync();
    //    return Ok(count);

    //    //we need to create a model then transfer the Domain to Dto here
    //    //implimentation pending and we need to mention the route
    //}


}
}
