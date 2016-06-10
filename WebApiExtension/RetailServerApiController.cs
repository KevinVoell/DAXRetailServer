using Microsoft.Dynamics.Commerce.Runtime.Client;
using Microsoft.Dynamics.Commerce.Runtime.Data;
using Microsoft.Dynamics.Retail.RetailServerLibrary.ODataControllers;
using System;
using System.Runtime.InteropServices;

namespace Retail.Server.Extensions.Example.WebApiExtension
{
    /// <summary>
    /// The RetailServerApiController extends the NonBindableActionController
    /// and uses relection to get access to some private fields.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Api", Justification = "Suppression is OK.")]
    [ComVisible(false)]
    public abstract class RetailServerApiController : NonBindableActionController
    {
        protected BusinessIntelligenceManager businessIntelligenceManager { get; private set; }
        protected ChannelManager channelManager { get; private set; }
        protected CustomerManager customerManager { get; private set; }
        protected InventoryManager inventoryManager { get; private set; }
        protected LayoutManager layoutManager { get; private set; }
        protected LoyaltyManager loyaltyManager { get; private set; }
        protected OfflineTransactionManager offlineTransactionManager { get; private set; }
        protected OrderManager orderManager { get; private set; }
        protected ProductManager productManager { get; private set; }
        protected SecurityManager securityManager { get; private set; }
        protected StoreOperationsManager storeOperationsManager { get; private set; }

        /// <summary>
        /// Gets the <c>CommerceIdentity</c> object for the current session.
        /// </summary>
        protected CommerceIdentity CommerceIdentity { get; private set; }

        /// <summary>
        /// The <c>Type</c> object of the base object.
        /// </summary>
        private Type baseType;

        protected RetailServerApiController()
        {
            baseType = this.GetType().BaseType.BaseType;
            productManager = GetField<ProductManager>("productManager");
            businessIntelligenceManager = GetField<BusinessIntelligenceManager>("businessIntelligenceManager");
            channelManager = GetField<ChannelManager>("channelManager");
            customerManager = GetField<CustomerManager>("customerManager");
            inventoryManager = GetField<InventoryManager>("inventoryManager");
            layoutManager = GetField<LayoutManager>("layoutManager");
            loyaltyManager = GetField<LoyaltyManager>("loyaltyManager");
            offlineTransactionManager = GetField<OfflineTransactionManager>("offlineTransactionManager");
            orderManager = GetField<OrderManager>("orderManager");
            securityManager = GetField<SecurityManager>("securityManager");
            storeOperationsManager = GetField<StoreOperationsManager>("storeOperationsManager");

            // Cast the Identity to a CommerceIdentity object
            CommerceIdentity = User.Identity as CommerceIdentity;
        }

        /// <summary>
        /// Gets a field from the base object.
        /// </summary>
        /// <typeparam name="T">The type of field to get.</typeparam>
        /// <param name="fieldName">The name of the private field in the base class.</param>
        /// <returns>The field from the base class.</returns>
        private T GetField<T>(string fieldName)
        {
            var property = baseType.GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (T)property.GetValue(this);
        }
    }
}
