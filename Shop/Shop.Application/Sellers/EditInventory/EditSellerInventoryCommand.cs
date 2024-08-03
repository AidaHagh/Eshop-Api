using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.EditInventory
{
    public class EditSellerInventoryCommand :IBaseCommand
    {
        public EditSellerInventoryCommand(long inventoryId, long sellerId, int count,
            int price, int? discountPercentage,string? color)
        {
            InventoryId = inventoryId;
            SellerId = sellerId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
            Color= color;
        }

        public long InventoryId { get; private set; }
        public long SellerId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }
        public string? Color { get; private set; }
    }
}
