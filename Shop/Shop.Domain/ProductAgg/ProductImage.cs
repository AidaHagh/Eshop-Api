using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(string imageName, int image_Order)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));   
            ImageName = imageName;
            Image_Order = image_Order;
        }

        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Image_Order { get; private set; }
    }
}
