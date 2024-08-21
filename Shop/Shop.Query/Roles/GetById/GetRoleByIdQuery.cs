using Common.Query;
using Shop.Query.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Roles.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;
