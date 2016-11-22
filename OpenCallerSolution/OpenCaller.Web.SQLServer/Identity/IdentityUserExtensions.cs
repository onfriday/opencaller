using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenCaller.Web.SQLServer.Identity
{
    public static class IdentityUserExtensions
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(AuthUserManager pManager, IdentityUser pUser, string pAuthenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await pManager.CreateIdentityAsync(pUser, pAuthenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
