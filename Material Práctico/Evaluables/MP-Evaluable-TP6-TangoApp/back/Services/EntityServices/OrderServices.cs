using back.Data.Repositories.Abstractions;
using back.Entities;

namespace back.Services.EntityServices
{
    public class OrderServices
    {
        IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order GetOrder(int orderId) => _orderRepository.Orders.Where(o => o.Id == orderId).First();
    }
}
