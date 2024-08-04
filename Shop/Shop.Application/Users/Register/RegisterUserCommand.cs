using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.Register
{
    public class RegisterUserCommand:IBaseCommand
    {
        public RegisterUserCommand(PhoneNumber phoneNumber, string password)
        {
            this.phoneNumber = phoneNumber;
            Password = password;
        }

        public PhoneNumber phoneNumber { get;private set; }
        public string Password { get;private set; }
    }
}
