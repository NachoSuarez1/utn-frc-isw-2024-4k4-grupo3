using back.Models;

namespace back.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
    }
}
