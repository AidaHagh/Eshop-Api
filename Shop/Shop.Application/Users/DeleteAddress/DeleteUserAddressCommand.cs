using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.DeleteAddress
{
    public record DeleteUserAddressCommand(long userId,long addressId):IBaseCommand;

}
