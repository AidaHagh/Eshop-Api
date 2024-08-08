using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enum;
using Shop.Domain.OrderAgg.IRepository;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }

        public async Task<Order?> GetCurrentUserOrder(long userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
                && f.Status == OrderStatus.Pending);
        }
    }
}
