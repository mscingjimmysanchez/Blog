using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog
{
    /// <summary>
    /// Global.asax.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Application start method.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void Application_Start(object sender, EventArgs e)
        {
            // Code that is executed starting the application
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}