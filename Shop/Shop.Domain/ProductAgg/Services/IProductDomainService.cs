using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg.Services
{
    //چک تکراری بودن اسلاگ
    public interface IProductDomainService
    {
        bool SlugIsExist(string slug);
    }
}
