using back.Entities;

namespace back.Data.Repositories.Abstractions
{
    public interface IOrderRepository
    {
       IEnumerable<Order> Orders { get; }
    }
}
