using Microsoft.Dynamics.Commerce.Runtime.Data;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Commerce.Runtime.Services.Messages;
using Microsoft.Dynamics.Commerce.Runtime.TransactionService;
using Microsoft.Dynamics.Retail.RetailServerLibrary;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace Retail.Server.Extensions.Example.WebApiExtension
{
    /// <summary>
    /// WebApi controller for real time service call to AX.
    /// </summary>
    [ComVisible(false)]
    [ExtendedController("DAXVersionRealTimeService")]
    [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Employee }, CheckRetailOperation = false, DeviceTokenRequired = false)]
    public class DAXVersionRealTimeServiceController : ApiController
    {
        protected CommerceIdentity CommerceIdentity;

        private TransactionServiceClient TransactionServiceClient;

        /// <summary>
        /// Default constructor
        /// </summary>
        public DAXVersionRealTimeServiceController()
        {
            // Need to set the ChannelId explicitly
            this.CommerceIdentity = User.Identity as CommerceIdentity;
            this.CommerceIdentity.ChannelId = 5637144662;

            TransactionServiceClient = new TransactionServiceClient(CommerceRuntimeManager.Runtime.CreateRequestContext(new RealtimeRequest()));
        }

        /// <summary>
        /// Gets the adjusted price for the specified itemId.
        /// </summary>
        /// <param name="itemId">The ItemId to find the price for.</param>
        /// <returns>The price or null if item is not found.</returns>
        /// <remarks>
        /// Called:
        /// http://[RetailServer]:8305/RetailServer/v1/api/DAXVersionRealTimeService
        /// </remarks>
        public string Get()
        {
            var version = "Unknown";

            var result = this.TransactionServiceClient.InvokeExtensionMethod("axVersion", new object[] { });

            
            var success = (bool)result[0];

            if (success)
            {
                version = (string)result[1];
            }

            return version;
        }
    }

    /// <summary>
    /// Concrete class needed to instantiate a <c>ServiceRequest</c>.
    /// </summary>
    internal class RealtimeRequest : ServiceRequest
    {
    }
}
