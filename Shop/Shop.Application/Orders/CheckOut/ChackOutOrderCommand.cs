using Common.Application;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.IRepository;
using Shop.Domain.OrderAgg.ValueObjects;
using Shop.Domain.SiteEntities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.CheckOut;

public class ChackOutOrderCommand : IBaseCommand
{
    public ChackOutOrderCommand(long userId, string shire, string city,
        string postalCode, string postalAddress, string phoneNumber,
        string name, string family, string nationalCode, long shippingMethodId)
    {
        UserId = userId;
        Province = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        ShippingMethodId = shippingMethodId;
    }

    public long UserId { get; private set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public long ShippingMethodId { get; private set; }
}
public class ChackOutOrderCommandHandler : IBaseCommandHandler<ChackOutOrderCommand>
{
    private readonly IOrderRepository _repository;
    private IShippingMethodRepository _shippingMethodRepository;

    public ChackOutOrderCommandHandler(IOrderRepository repository, IShippingMethodRepository shippingMethodRepository)
    {
        _repository = repository;
        _shippingMethodRepository = shippingMethodRepository;
    }

    public async Task<OperationResult> Handle(ChackOutOrderCommand request, CancellationToken cancellationToken)
    {
        var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
        if (currentOrder == null)
            return OperationResult.NotFound();

        var address = new OrderAddress(request.Province,request.City,request.PostalCode,
            request.PostalAddress,request.PhoneNumber,request.Name,request.Family,
            request.NationalCode);

        var shippingMethod = await _shippingMethodRepository.GetAsync(request.ShippingMethodId);
        if (shippingMethod == null)
            return OperationResult.Error();

        currentOrder.Checkout(address, new OrderShippingMethod(shippingMethod.Title, shippingMethod.Cost));
        await _repository.Save();
        return OperationResult.Success();

    }
}

