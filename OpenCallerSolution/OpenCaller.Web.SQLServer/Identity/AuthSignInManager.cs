using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace OpenCaller.Web.SQLServer.Identity
{
    // Configure the application sign-in manager which is used in this application.
    public sealed class AuthSignInManager : SignInManager<IdentityUser, string>
    {
        public AuthSignInManager(AuthUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}

