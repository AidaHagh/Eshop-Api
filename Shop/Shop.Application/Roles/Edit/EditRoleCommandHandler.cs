using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.IRepository;

namespace Shop.Application.Roles.Edit
{
    internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public EditRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetTracking(request.Id, cancellationToken);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);

            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(p =>
            {
                permissions.Add(new RolePermission(p));
            });
            role.SetPermissions(permissions);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
