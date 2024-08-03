using Common.Application;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Create
{
    public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;
}
