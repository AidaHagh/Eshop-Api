using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
    internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly ShopContext _context;

        public GetCategoryListQueryHandler(ShopContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories
                .Where(r => r.ParentId == null)
                .Include(c => c.Childs)
                .ThenInclude(c => c.Childs)
                .OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
            return model.Map();
        }
    }

}
