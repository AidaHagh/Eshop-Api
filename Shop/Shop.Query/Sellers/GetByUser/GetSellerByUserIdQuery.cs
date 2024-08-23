using Common.Query;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Sellers.GetByUser;

public record GetSellerByUserIdQuery(long UserId):IQuery<SellerDto?>;
