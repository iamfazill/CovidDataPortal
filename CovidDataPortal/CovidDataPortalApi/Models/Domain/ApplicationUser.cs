using Microsoft.AspNetCore.Identity;

namespace CovidDataPortalApi.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
