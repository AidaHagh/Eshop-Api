using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.IRepositories;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
    internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
    {
        public ShippingMethodRepository(ShopContext context) : base(context)
        {
        }

        public void Delete(ShippingMethod method)
        {
            Context.ShippingMethods.Remove(method);
        }
    }
}
