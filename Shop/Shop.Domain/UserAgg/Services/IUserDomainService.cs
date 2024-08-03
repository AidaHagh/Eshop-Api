using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        bool IsExistEmail(string email);

        bool IsExistPhoneNumber(string phoneNumber);
    }
}
