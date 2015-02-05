/*
SAMPLE CODE NOTICE

THIS SAMPLE CODE IS MADE AVAILABLE AS IS.  MICROSOFT MAKES NO WARRANTIES, WHETHER EXPRESS OR IMPLIED, 
OF FITNESS FOR A PARTICULAR PURPOSE, OF ACCURACY OR COMPLETENESS OF RESPONSES, OF RESULTS, OR CONDITIONS OF MERCHANTABILITY.  
THE ENTIRE RISK OF THE USE OR THE RESULTS FROM THE USE OF THIS SAMPLE CODE REMAINS WITH THE USER.  
NO TECHNICAL SUPPORT IS PROVIDED.  YOU MAY NOT DISTRIBUTE THIS CODE UNLESS YOU HAVE A LICENSE AGREEMENT WITH MICROSOFT THAT ALLOWS YOU TO DO SO.
*/

namespace Microsoft.Dynamics.RetailServer.Samples.Extensions
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Web.Http;
    using Commerce.Runtime.DataModel;

    using Microsoft.Dynamics.Retail.RetailServerLibrary;
    using System.Composition;

    /// <summary>
    /// The values controller.
    /// </summary>
    [ComVisible(false)]
    [ExtendedController("Values")]
    //[Export(typeof(IWebApiConfig))]
    [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Anonymous }, CheckRetailOperation = false, DeviceTokenRequired = false)]
    public class ValuesController : ApiController//, IWebApiConfig
    {
        public ValuesController()
        {
            System.IO.File.AppendAllText(@"C:\temp\trace.log", "Called Constructor");
        }

        /// <summary>
        /// Gets API values
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //public void Register(HttpConfiguration config)
        //{
        //    System.IO.File.AppendAllText(@"C:\temp\trace.log", "Called Register");

        //    config.Services.Add(typeof(ValuesController), this);
        //}
    }
}
