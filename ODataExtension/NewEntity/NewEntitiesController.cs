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
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    using Microsoft.Dynamics.Commerce.Runtime.DataModel;
    using Microsoft.Dynamics.Retail.RetailServerLibrary;
    using Microsoft.Dynamics.Retail.RetailServerLibrary.ODataControllers;

    [ComVisible(false)]
    [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Anonymous }, CheckRetailOperation = false, DeviceTokenRequired = false)]
    public class NewEntitiesController : CommerceController<NewEntity, string>
    {
        [HttpGet]
        public override System.Linq.IQueryable<NewEntity> Get()
        {
            List<NewEntity> newEntities = new List<NewEntity>();

            for (int i = 0; i < 10; i++)
            {
                var newEntity = new NewEntity();
                newEntity.Id = "Id" + i;
                newEntity.Name = "Name" + i;

                newEntities.Add(newEntity);
            }

            return newEntities.AsQueryable();
        }
    }
}
