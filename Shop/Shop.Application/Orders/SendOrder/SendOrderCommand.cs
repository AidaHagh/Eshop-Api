using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.SendOrder;

public class SendOrderCommand : IBaseCommand
{
    public SendOrderCommand(long orderId)
    {
        OrderId = orderId;
    }

    public long OrderId { get; private set; }
}
