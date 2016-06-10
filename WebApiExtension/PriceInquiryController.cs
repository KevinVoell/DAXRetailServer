using Microsoft.Dynamics.Commerce.Runtime;
using Microsoft.Dynamics.Commerce.Runtime.Client;
using Microsoft.Dynamics.Commerce.Runtime.Configuration;
using Microsoft.Dynamics.Commerce.Runtime.Data;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Retail.RetailServerLibrary;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace Retail.Server.Extensions.Example.WebApiExtension
{
    /// <summary>
    /// WebApi controller for anonymous price inquiry.
    /// </summary>
    [ComVisible(false)]
    [ExtendedController("PriceInquiry")]
    [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Anonymous }, CheckRetailOperation = false, DeviceTokenRequired = false)]
    public class PriceInquiryController : ApiController
    {
        protected CommerceIdentity CommerceIdentity;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PriceInquiryController()
        {
            // Need to set the ChannelId explicitly
            this.CommerceIdentity = User.Identity as CommerceIdentity;
            this.CommerceIdentity.ChannelId = 5637144662;
        }

        /// <summary>
        /// Gets the adjusted price for the specified itemId.
        /// </summary>
        /// <param name="itemId">The ItemId to find the price for.</param>
        /// <returns>The price or null if item is not found.</returns>
        /// <remarks>
        /// Called:
        /// http://[RetailServer]:8305/RetailServer/v1/api/PriceInquiry?ItemId=12345
        /// </remarks>
        public decimal Get(string itemId)
        {
            ThrowIf.NullOrWhiteSpace(itemId, "itemId");

            var searchCriteria = new ProductSearchCriteria(this.CommerceIdentity.ChannelId)
            {
                SkipVariantExpansion = true,
                DataLevel = CommerceEntityDataLevel.Minimal,
                DownloadProductData = false,
                IncludeProductsFromDescendantCategories = false,
                ItemIds = new[] { new ProductLookupClause(itemId) }
            };

            var products = GetProductManager().SearchProducts(searchCriteria, new QueryResultSettings(new PagingInfo(1, 0)));

            if (products.Results.Count > 0)
            {
                return products.Results[0].AdjustedPrice;
            }

            return -1;
        }

        private ProductManager GetProductManager()
        {
            var connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            var configurationSection = CommerceRuntimeConfigurationManager.GetConfigurationSection(CommerceRuntimeConfigurationManager.SectionName);
            var configuration = new CommerceRuntimeConfiguration(configurationSection, connectionString);

            var principal = new CommercePrincipal(this.CommerceIdentity);

            var runtime = CommerceRuntime.Create(configuration, principal);
            var pm = ProductManager.Create(runtime);

            return pm;
        }
    }
}
