using OpenCaller.Web.IoC;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace OpenCaller.Mobile.Backend
{
    public static class SimpleInjectorInitializer
    {
        public static Container Initialize(IAppBuilder pApp)
        {
            var _container = new Container();
            _container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            _container.RegisterSingleton(pApp);

            BootStrapper.Initialize(pApp, _container);

            RegisterPresentationRepositories(_container);

            _container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            _container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);

            return _container;
        }

        private static void RegisterPresentationRepositories(Container pContainer)
        {
            //pContainer.RegisterPerWebRequest<Repositories.ProdutosControllerRepository>();
        }
    }
}