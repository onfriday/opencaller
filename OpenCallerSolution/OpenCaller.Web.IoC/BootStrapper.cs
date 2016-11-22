using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using OpenCaller.Web.SQLServer;
using OpenCaller.Web.SQLServer.Adapters;
using OpenCaller.Web.SQLServer.Identity;
using Owin;
using SimpleInjector;
using System.Web;

namespace OpenCaller.Web.IoC
{
    public class BootStrapper
    {
        public static void Initialize(IAppBuilder pApp, Container pContainer)
        {
            var _globalLifestyle = Lifestyle.Scoped;

            pContainer.Register(() => new OpenCallerDbContext(), _globalLifestyle);

            ConfigureIdentity(pApp, pContainer, _globalLifestyle);

            ConfigureContainer(pContainer);

            pContainer.Register<SQLServerTypeAdapter>(_globalLifestyle);

            RegisterCoreRepositories(pContainer, _globalLifestyle);

            RegisterCoreServices(pContainer, _globalLifestyle);
        }

        private static void ConfigureContainer(Container pContainer)
        {
            pContainer.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && pContainer.IsVerifying)
                    return new OwinContext().Authentication;

                return HttpContext.Current.GetOwinContext().Authentication;
            });
        }

        private static void ConfigureIdentity(IAppBuilder pApp, Container pContainer, Lifestyle pGlobalLifestyle)
        {
            pContainer.Register(() => new UserStore<IdentityUser>(pContainer.GetInstance<OpenCallerDbContext>()), pGlobalLifestyle);
            pContainer.Register(() => new AuthUserManager(pContainer.GetInstance<UserStore<IdentityUser>>()), pGlobalLifestyle);
            pContainer.RegisterInitializer<AuthUserManager>(manager => AuthUserManagerInitializer.Initialize(pApp, manager));
            pContainer.Register(() => new AuthSignInManager(pContainer.GetInstance<AuthUserManager>(), pContainer.GetInstance<IAuthenticationManager>()), pGlobalLifestyle);
        }

        private static void RegisterCoreRepositories(Container pContainer, Lifestyle pGlobalLifestyle)
        {
            //pContainer.Register<CadastroAnimalServiceRepository, CadastroAnimalServiceWebRepository>(pGlobalLifestyle);
            //pContainer.Register<CadastroAnimalTipoServiceRepository, CadastroAnimalTipoServiceWebRepository>(pGlobalLifestyle);

            //pContainer.Register<CadastroEspecialidadeServiceRepository, CadastroEspecialidadeServiceWebRepository>(pGlobalLifestyle);

            //pContainer.Register<CadastroPersonalidadeServiceRepository, CadastroPersonalidadeServiceWebRepository>(pGlobalLifestyle);

            //pContainer.Register<CadastroPorteServiceRepository, CadastroPorteServiceWebRepository>(pGlobalLifestyle);

            //pContainer.Register<CadastroRacaServiceRepository, CadastroRacaServiceWebRepository>(pGlobalLifestyle);

            //pContainer.Register<AcessoServiceRepository, AcessoServiceWebRepository>(pGlobalLifestyle);
        }

        private static void RegisterCoreServices(Container pContainer, Lifestyle pGlobalLifestyle)
        {
            //pContainer.Register<CadastroAnimalService>(pGlobalLifestyle);
            //pContainer.Register<CadastroAnimalTipoService>(pGlobalLifestyle);

            //pContainer.Register<CadastroEspecialidadeService>(pGlobalLifestyle);

            //pContainer.Register<CadastroPersonalidadeService>(pGlobalLifestyle);

            //pContainer.Register<CadastroPorteService>(pGlobalLifestyle);

            //pContainer.Register<CadastroRacaService>(pGlobalLifestyle);

            //pContainer.Register<AcessoService>(pGlobalLifestyle);
        }
    }
}
