using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleWebFormsGame
{
    public class Global : HttpApplication
    {
        //todo: Add global and pages level error handling

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}