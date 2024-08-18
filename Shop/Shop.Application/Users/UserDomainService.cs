using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        public bool IsExistEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsExistPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
