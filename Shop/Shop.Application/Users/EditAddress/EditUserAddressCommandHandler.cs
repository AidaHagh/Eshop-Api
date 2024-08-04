using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.IRepository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.EditAddress
{
    internal class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
    {
        private readonly IUserDomainService _domainService;
        private readonly IUserRepository _repository;

        public EditUserAddressCommandHandler(IUserDomainService domainService, IUserRepository repository)
        {
            _domainService = domainService;
            _repository = repository;
        }
        public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId, cancellationToken);
            if (user == null)
                return OperationResult.NotFound();

            var address = new UserAddress(request.Province, request.City, request.PostalCode,
                    request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.NationalCode);

            user.EditAddress(address, request.Id);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
