using Common.Application;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.IRepository;

namespace Shop.Application.Sellers.AddInventory;

internal class AddSellerInventoryCommandHandler : IBaseCommandHandler<AddSellerInventoryCommand>
{
    private readonly ISellerRepository _repository;

    public AddSellerInventoryCommandHandler(ISellerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddSellerInventoryCommand request, CancellationToken cancellationToken)
    {
        var seller = await _repository.GetTracking(request.SellerId,cancellationToken);
        if (seller == null)
            return OperationResult.NotFound();

        var sellerInventory=new SellerInventory(request.ProductId,request.Count,
            request.Price,request.DiscountPercentage,request.Color);
        seller.AddInventory(sellerInventory);
        await _repository.Save();
        return OperationResult.Success();   
    }
}



