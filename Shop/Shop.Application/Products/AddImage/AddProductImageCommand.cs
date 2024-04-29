using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommand : IBaseCommand
    {
        public AddProductImageCommand(IFormFile imageFile,
            long productId, int orderOfImage)
        {
            ImageFile = imageFile;
            ProductId = productId;
            OrderOfImage = orderOfImage;
        }

        public IFormFile ImageFile { get; private set; }
        public long ProductId { get; private set; }
        public int OrderOfImage { get; private set; }
    }
}
