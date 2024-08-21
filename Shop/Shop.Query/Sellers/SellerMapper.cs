using Shop.Domain.SellerAgg;
using Shop.Query.Sellers.DTOs;


namespace Shop.Query.Sellers
{
    public static class SellerMapper
    {
        public static SellerDto Map(this Seller seller)
        {
            if (seller == null)
                return null;

            return new SellerDto()
            {
                Id = seller.Id,
                CreationDate = seller.CreationDate,
                NationalCode = seller.NationalCode,
                ShopName = seller.ShopName,
                Status = seller.Status, 
                UserId = seller.UserId,

            };
        }
    }
}
