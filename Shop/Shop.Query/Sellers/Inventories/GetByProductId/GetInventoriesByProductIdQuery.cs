using Common.Query;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.Inventories.GetByProductId;

public record GetInventoriesByProductIdQuery(long ProductId) : IQuery<List<InventoryDto>>;
