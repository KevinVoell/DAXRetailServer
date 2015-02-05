/*
SAMPLE CODE NOTICE

THIS SAMPLE CODE IS MADE AVAILABLE AS IS.  MICROSOFT MAKES NO WARRANTIES, WHETHER EXPRESS OR IMPLIED, 
OF FITNESS FOR A PARTICULAR PURPOSE, OF ACCURACY OR COMPLETENESS OF RESPONSES, OF RESULTS, OR CONDITIONS OF MERCHANTABILITY.  
THE ENTIRE RISK OF THE USE OR THE RESULTS FROM THE USE OF THIS SAMPLE CODE REMAINS WITH THE USER.  
NO TECHNICAL SUPPORT IS PROVIDED.  YOU MAY NOT DISTRIBUTE THIS CODE UNLESS YOU HAVE A LICENSE AGREEMENT WITH MICROSOFT THAT ALLOWS YOU TO DO SO.
*/

namespace Microsoft.Dynamics.RetailServer.Samples.Extensions
{
    using System;
    using System.Composition;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    using Microsoft.Dynamics.Retail.RetailServerLibrary;

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
                System.IO.File.AppendAllText(@"C:\temp\trace.log", "Config is null.");
                throw new ArgumentNullException("config");
            }

            //System.Threading.Thread.Sleep(1000 * 30);

            base.Register(config);

            //config.Services.Add(typeof(IWebApiConfig), new ValuesController());

            // Enables the web api non-OData routes mapping.
            config.Routes.MapHttpRoute(
            name: "API Default",
            routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            System.IO.File.AppendAllText(@"C:\temp\trace.log", "Finished Register on ExtendedWebApiConfig");
        }
    }
}
