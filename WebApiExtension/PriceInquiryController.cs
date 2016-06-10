using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Retail.RetailServerLibrary;
using System.Runtime.InteropServices;

namespace Retail.Server.Extensions.Example.WebApiExtension
{
    /// <summary>
    /// WebApi controller for anonymous price inquiry.
    /// </summary>
    [ComVisible(false)]
    [ExtendedController("PriceInquiry")]
    [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Anonymous }, CheckRetailOperation = false, DeviceTokenRequired = false)]
    public class PriceInquiryController : RetailServerApiController
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public PriceInquiryController()
        {
            // Need to set the ChannelId explicitly
            this.CommerceIdentity.ChannelId = 12345678;
        }

        /// <summary>
        /// Lookup a barcode using the ProductController.
        /// </summary>
        /// <param name="barcode">The barcode to lookup.</param>
        /// <returns>An instnce of <c>Barcode</c>.</returns>
        public Barcode Get(string barcode)
        {
            var retVal = this.productManager.GetBarcode(new ScanInfo { EntryMethodType = BarcodeEntryMethodType.SingleScanned, ScanDataLabel = barcode },
                QueryResultSettings.Default);

            return retVal;
        }
    }
}
