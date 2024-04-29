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
        public ProductImage(string imageName, int orderOfImage)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));   
            ImageName = imageName;
            OrderOfImage = orderOfImage;
        }

        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int OrderOfImage { get; private set; }
    }
}
