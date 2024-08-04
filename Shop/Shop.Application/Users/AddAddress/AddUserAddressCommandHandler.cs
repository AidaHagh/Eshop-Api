using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.IRepository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.AddAddress;

internal class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
{
    private readonly IUserDomainService _domainService;
    private readonly IUserRepository _repository;

    public AddUserAddressCommandHandler(IUserDomainService domainService, IUserRepository repository)
    {
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId, cancellationToken);
        if (user == null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.Province, request.City, request.PostalCode,
            request.PostalAddress, request.PhoneNumber, request.Name, request.Family, request.NationalCode);


        user.AddAddress(address);
        await _repository.Save();
        return OperationResult.Success();
    }
}

