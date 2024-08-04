using Common.Application;
using Shop.Domain.UserAgg.IRepository;

namespace Shop.Application.Users.DeleteAddress
{
    internal class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
    {
        private readonly IUserRepository _Repository;

        public DeleteUserAddressCommandHandler(IUserRepository repository)
        {
            _Repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _Repository.GetTracking(request.userId,cancellationToken);
            if (user == null)
                return OperationResult.NotFound();

            user.DeleteAddress(request.addressId);
            await _Repository.Save();
            return OperationResult.Success();
        
        
        }
    }

}
