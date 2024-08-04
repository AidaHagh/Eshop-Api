using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.IRepository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create;

internal class CreateCommandUserHandler : IBaseCommandHandler<CreateCommandUser>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _domainService;
    public CreateCommandUserHandler(IUserRepository repository, IUserDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateCommandUser request, CancellationToken cancellationToken)
    {
        var hashPassword = Sha256Hasher.Hash(request.Password);
        var user = new User(request.Name, request.Family, request.PhoneNumber,
            request.Email, hashPassword, request.Gender, _domainService);
        _repository.Add(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}


