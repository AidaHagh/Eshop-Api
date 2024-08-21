using Common.Query;
using Shop.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber):IQuery<UserDto?>;
