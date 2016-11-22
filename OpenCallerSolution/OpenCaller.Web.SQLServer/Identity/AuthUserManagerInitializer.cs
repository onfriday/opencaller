using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;

namespace OpenCaller.Web.SQLServer.Identity
{
    public static class AuthUserManagerInitializer
    {
        public static void Initialize(IAppBuilder pApp, AuthUserManager pManager)
        {
            // Configure validation logic for usernames
            pManager.UserValidator = new UserValidator<IdentityUser>(pManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            pManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            pManager.UserLockoutEnabledByDefault = true;
            pManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            pManager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            //pManager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<OnFridayUser>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});

            //pManager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<OnFridayUser>
            //{
            //    Subject = "Security Code",
            //    BodyFormat = "Your security code is {0}"
            //});

            //pManager.EmailService = new EmailService();
            //pManager.SmsService = new SmsService();

            var dataProtectionProvider = pApp.GetDataProtectionProvider();

            if (dataProtectionProvider != null)
                pManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create("Vetnanet"));
        }
    }
}
