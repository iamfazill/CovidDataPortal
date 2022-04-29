using CovidDataPortalApi.Models.Domain;
using CovidDataPortalApi.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CovidDataPortalApi.Repositories
{   public interface IAccountRepository
    {
        Task<IdentityResult> signUpAsyncc(SignUpModel signup);
        Task<string> loginAsyncc(SignInModel signin);

    }
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public SignInManager<ApplicationUser> _SignInManager { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _SignInManager = signInManager;
            _configuration = configuration;
        }

        

        public async Task<IdentityResult> signUpAsyncc(SignUpModel signup)
        {
            var user = new ApplicationUser()
            {
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                Email = signup.Email,
                UserName = signup.Email
            };
          var result= await _userManager.CreateAsync(user,signup.Password);
            return result;

        }

        public async Task<string> loginAsyncc(SignInModel signin)
        {
            var result = await _SignInManager.PasswordSignInAsync(signin.Email, signin.Password, false, false);

            if(!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,signin.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken
                (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256Signature)
                ); 


          return  new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
