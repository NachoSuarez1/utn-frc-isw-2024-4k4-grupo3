using back.Entities;

namespace back.Data.Repositories.Abstractions
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
    }
}
