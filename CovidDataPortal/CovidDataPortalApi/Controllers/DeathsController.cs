using AutoMapper;
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
        public async  Task<IActionResult> GetAllDeaths()
        {
          var deaths= await DeathRepository.getallDeathsAsync();
          var DeathsDTO=  Mapper.Map<List<Models.DTO.Deaths>>(deaths);
             
            return Ok(DeathsDTO);
        }
    }
}
