using back.Models;

namespace back.Repositories.Abstractions
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
    }
}
