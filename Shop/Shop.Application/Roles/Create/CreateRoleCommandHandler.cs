using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.IRepository;

namespace Shop.Application.Roles.Create
{
    internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions = new List<RolePermission>();

            request.Permissions.ForEach(p =>
            {
                permissions.Add(new RolePermission(p));

            });
            var role = new Role(request.Title, permissions);
            _repository.Add(role);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
