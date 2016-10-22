using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace CargoManager.Api.App_Start
{
    public static class WebApiConfig
    {
        private const string API_BASE_PATH = "api/v1/";

        private static readonly HttpMethodConstraint postConstraint = new HttpMethodConstraint(new HttpMethod[1] { HttpMethod.Post });
        private static readonly HttpMethodConstraint getConstraint = new HttpMethodConstraint(new HttpMethod[1] { HttpMethod.Get });
        private static readonly HttpMethodConstraint putConstraint = new HttpMethodConstraint(new HttpMethod[1] { HttpMethod.Put });
        private static readonly HttpMethodConstraint deleteConstraint = new HttpMethodConstraint(new HttpMethod[1] { HttpMethod.Delete });

        public static void Register(HttpConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Web API configuration and services
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //#if DEBUG
            //            config.EnableSystemDiagnosticsTracing();
            //#endif

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "get_cargos", 
                routeTemplate: API_BASE_PATH + "cargos", 
                defaults: new { controller = ControllersNames.CARGOS, action = ActionNames.GET_CARGOS }, 
                constraints: new { httpMethod = getConstraint });

            config.Routes.MapHttpRoute(
                name: "search_cargos",
                routeTemplate: API_BASE_PATH + "cargos/_search",
                defaults: new { controller = ControllersNames.CARGOS, action = ActionNames.SEARCH_CARGOS },
                constraints: new { httpMethod = postConstraint });
        }
    }
}