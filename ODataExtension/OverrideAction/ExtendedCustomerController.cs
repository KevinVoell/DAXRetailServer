/*
SAMPLE CODE NOTICE

THIS SAMPLE CODE IS MADE AVAILABLE AS IS.  MICROSOFT MAKES NO WARRANTIES, WHETHER EXPRESS OR IMPLIED, 
OF FITNESS FOR A PARTICULAR PURPOSE, OF ACCURACY OR COMPLETENESS OF RESPONSES, OF RESULTS, OR CONDITIONS OF MERCHANTABILITY.  
THE ENTIRE RISK OF THE USE OR THE RESULTS FROM THE USE OF THIS SAMPLE CODE REMAINS WITH THE USER.  
NO TECHNICAL SUPPORT IS PROVIDED.  YOU MAY NOT DISTRIBUTE THIS CODE UNLESS YOU HAVE A LICENSE AGREEMENT WITH MICROSOFT THAT ALLOWS YOU TO DO SO.
*/

namespace Microsoft.Dynamics.RetailServer.ExtensionSamples
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    using Microsoft.Dynamics.Commerce.Runtime.DataModel;
    using Microsoft.Dynamics.Retail.RetailServerLibrary;
    using Microsoft.Dynamics.Retail.RetailServerLibrary.ODataControllers;

    [ExtendedController("Customers")]
    [ComVisible(false)]
    public class ExtendedCustomersController : CustomersController
    {
        [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Anonymous }, CheckRetailOperation = false, DeviceTokenRequired = false)]
        public override IQueryable<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                var customer = new Customer();
                customer.AccountNumber = "customer" + i;
                customer.Name = "Name" + i;
                
                customers.Add(customer);
            }

            return customers.AsQueryable();
        }
    }
}
