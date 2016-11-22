using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OpenCaller.Web.SQLServer.Identity
{
    public sealed class AuthUserManager : UserManager<IdentityUser>
    {
        public AuthUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
        }
    }
}
