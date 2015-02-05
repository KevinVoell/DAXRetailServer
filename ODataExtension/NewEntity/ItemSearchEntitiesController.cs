using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using Microsoft.Dynamics.Retail.RetailServerLibrary;
using Microsoft.Dynamics.Retail.RetailServerLibrary.ODataControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Microsoft.Dynamics.RetailServer.Samples.Extensions.ODataExtension.NewEntity
{
    [ComVisible(false)]
    [CommerceAuthorization(AllowedRetailRoles = new string[] { CommerceRoles.Anonymous }, CheckRetailOperation = false, DeviceTokenRequired = false)]
    public class ItemSearchEntitiesController : CommerceController<ItemSearchEntity, string>
    {
        [HttpGet]
        public override System.Linq.IQueryable<ItemSearchEntity> Get()
        {
            List<ItemSearchEntity> newEntities = new List<ItemSearchEntity>();

            for (int i = 0; i < 10; i++)
            {
                var newEntity = new ItemSearchEntity();
                newEntity.ItemId = "Id" + i;
                newEntity.ItemName = "Name" + i;

                newEntities.Add(newEntity);
            }

            return newEntities.AsQueryable();
        }
    }
}
