using CovidDataPortalApi.Models.Domain;
using CovidDataPortalApi.Models.DTO;
using CovidDataPortalApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidDataPortalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignupAsync([FromBody] SignUpModel signUp)
        {
            var result =await _accountRepository.signUpAsyncc(signUp);
            if (result != null)
            {
                return Ok(true);
            }
            return Unauthorized(); 
        }


        [HttpPost("log-in")]
        public async Task<IActionResult> Loginasync([FromBody] SignInModel login)
        {
            var result = await _accountRepository.loginAsyncc(login);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}
