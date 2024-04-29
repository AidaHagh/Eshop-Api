using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.IRepository;

namespace Shop.Application.Rols.Create
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
            var permitions = new List<RolePermission>();

            request.Permissions.ForEach(f =>
            {
                permitions.Add(new RolePermission(f));

            });
            var role = new Role(request.Title, permitions);
            _repository.Add(role);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
