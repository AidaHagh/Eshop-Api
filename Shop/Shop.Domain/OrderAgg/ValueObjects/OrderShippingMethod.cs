using Common.Domain;


namespace Shop.Domain.OrderAgg.ValueObjects
{
    public class OrderShippingMethod : BaseValueObject
    {
        public OrderShippingMethod(string shippingType, int shippingCost)
        {
            ShippingType = shippingType;
            ShippingCost = shippingCost;
        }

        public string ShippingType { get; private set; }
        public int ShippingCost { get; private set; }
    }
}
