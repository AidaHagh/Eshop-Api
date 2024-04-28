using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.IRepository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    private readonly ICategoryDomainService _domainService;

    public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.title, request.slug, request.SeoData, _domainService);
        _repository.Add(category);
        await _repository.Save();
        return OperationResult.Success();
    }
}

