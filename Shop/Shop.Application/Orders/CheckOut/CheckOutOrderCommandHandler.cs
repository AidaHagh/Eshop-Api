using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.IRepository;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SiteEntities.IRepositories;

namespace Shop.Application.Orders.CheckOut;

public class CheckOutOrderCommandHandler : IBaseCommandHandler<CheckOutOrderCommand>
{
    private readonly IOrderRepository _repository;
    private IShippingMethodRepository _shippingMethodRepository;

    public CheckOutOrderCommandHandler(IOrderRepository repository, IShippingMethodRepository shippingMethodRepository)
    {
        _repository = repository;
        _shippingMethodRepository = shippingMethodRepository;
    }

    public async Task<OperationResult> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
            return OperationResult.NotFound();

        var address = new OrderAddress(request.Province,request.City,request.PostalCode,
            request.PostalAddress,request.PhoneNumber,request.Name,request.Family,
            request.NationalCode);

        var shippingMethod = await _shippingMethodRepository.GetAsync(request.ShippingMethodId, cancellationToken);
        if (shippingMethod == null)
            return OperationResult.Error();

        currentOrder.Checkout(address, new OrderShippingMethod(shippingMethod.Title, shippingMethod.Cost));
        await _repository.Save();
        return OperationResult.Success();

    }
}

