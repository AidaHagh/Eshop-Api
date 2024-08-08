using Common.Query;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetById
{
    public record GetCategoryByIdQuery(long CategoryId):IQuery<CategoryDto>;

}
