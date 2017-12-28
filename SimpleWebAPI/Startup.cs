using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(SimpleWebAPI.API.Startup))]
namespace SimpleWebAPI.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureOAuth(app);

            //ParseClient.Initialize(new ParseClient.Configuration
            //{
            //    ApplicationId = "03fc3ba8fb8e4517821deec01503233e",
            //    Server = "https://avila-pushservice.azurewebsites.net/parse/"
            //});

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }


    }
}