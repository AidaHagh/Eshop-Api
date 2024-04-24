using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg.Enum
{
    public enum OrderStatus
    {
        Pending,
        Finally,
        Shipping,
        Rejected
    }
}
