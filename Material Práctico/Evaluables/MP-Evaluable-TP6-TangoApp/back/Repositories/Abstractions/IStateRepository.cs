using back.Models;

namespace back.Repositories.Abstractions
{
    public interface IStateRepository
    {
        IEnumerable<State> States { get; }

        State GetConfirmed();
        State GetDiscarded();
    }
}
