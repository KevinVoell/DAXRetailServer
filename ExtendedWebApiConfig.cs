using System;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Composition;
using Microsoft.Dynamics.Retail.RetailServerLibrary;

namespace Retail.Server.Extensions.Example
{
    /// <summary>
    /// The extended web API config.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api", Justification = "Suppression is OK.")]
    [Export(typeof(IWebApiConfig))]
    [ComVisible(false)]
    public class ExtendedWebApiConfig : DefaultWebApiConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <exception cref="ArgumentNullException">If any issues with configuration.
        /// </exception>
        public override void Register(System.Web.Http.HttpConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            base.Register(config);

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "V1/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
