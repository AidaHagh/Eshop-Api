using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetById;

public class GetUserByIdQuery:IQuery<UserDto?>
{
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;    
    }
    public long UserId { get;private set; }
}
