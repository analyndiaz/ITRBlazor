using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Evolve.ITR.Infrastructure.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAzureADUser { get; set; }

    }
}
