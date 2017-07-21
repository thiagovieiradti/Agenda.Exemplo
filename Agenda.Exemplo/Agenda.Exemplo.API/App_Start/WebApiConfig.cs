using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Agenda.Exemplo.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Injetor.Injetor.IniciarContainer();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Injetor.Injetor.Container);

        }
    }
}
