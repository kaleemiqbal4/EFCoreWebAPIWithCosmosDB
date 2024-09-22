using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;
using EFCoreCosmosDB.Repository.Integration.Contract;
using Microsoft.Extensions.Logging;

namespace EFCoreCosmosDB.Application.Concrete;

public class OrderManager : IOrderManager
{
    private readonly IOrderRepository orderRepository;
    private readonly ILogger<OrderManager> logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_orderRepository"></param>
    /// <param name="_logger"></param>
    /// <param name="_wrapper"></param>
    public OrderManager(IOrderRepository _orderRepository, ILogger<OrderManager> _logger) => (orderRepository, logger) = (_orderRepository, _logger);

    public async Task<int> CreateOrderAsync(OrderRequest request)
    {
        OrderEntity oe = new OrderEntity
        {
            Id = "4",
            UserId = request.UserId,
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
        };
        await orderRepository.AddAsync(oe);
        return 1; // await wrapper.SaveChangesAsync();
    }

    public async Task<List<OrderResponse>> OrderListAsync()
    {
        var result = await orderRepository.GetAllAsync();
        var orderResponses = new List<OrderResponse>();
        result.ToList().ForEach(order => orderResponses.Add(new OrderResponse
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount
        }));
        return orderResponses;
    }
}
