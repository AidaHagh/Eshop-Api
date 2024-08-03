using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.AddInventory;

public class AddSellerInventoryCommand : IBaseCommand
{
    public AddSellerInventoryCommand(long sellerId, long productId, int count,
        int price, int? discountPercentage, string? color)
    {
        SellerId = sellerId;
        ProductId = productId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
        Color = color;
    }

    public long SellerId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }
    public string? Color { get; private set; }

}



