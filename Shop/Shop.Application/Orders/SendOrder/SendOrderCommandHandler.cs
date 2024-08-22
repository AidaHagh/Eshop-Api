using Common.Application;
using Shop.Domain.OrderAgg.Enum;
using Shop.Domain.OrderAgg.IRepository;

namespace Shop.Application.Orders.SendOrder;

public class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public SendOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetTracking(request.OrderId,cancellationToken);
        if (order == null)
            return OperationResult.NotFound();

        order.ChangeStatus(OrderStatus.Shipping);
        await _orderRepository.Save();
        return OperationResult.Success();
    }
}
