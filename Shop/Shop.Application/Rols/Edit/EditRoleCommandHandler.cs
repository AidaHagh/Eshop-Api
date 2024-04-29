using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.IRepository;

namespace Shop.Application.Rols.Edit
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
            var role=await _repository.GetTracking(request.Id);
            if (role == null)
                return OperationResult.NotFound();

            role.Edit(request.Title);

            var permitions=new List<RolePermission>();
            request.Permissions.ForEach(p =>
            {
                permitions.Add(new RolePermission(p));  
            });
            role.SetPermissions(permitions);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
