using Common.Domain.Exceptions;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities
{
    public class ShippingMethod : BaseEntity
    {
        public ShippingMethod(int cost, string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Cost = cost;
            Title = title;
        }

        public void Edit(int cost, string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Cost = cost;
            Title = title;
        }
        public string Title { get; private set; }
        public int Cost { get; private set; }
    }
}
