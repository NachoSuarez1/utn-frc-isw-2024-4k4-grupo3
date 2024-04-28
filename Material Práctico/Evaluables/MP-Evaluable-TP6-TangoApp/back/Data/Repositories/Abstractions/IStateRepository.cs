using back.Entities;

namespace back.Data.Repositories.Abstractions
{
    public interface IStateRepository
    {
        IEnumerable<State> States { get; }

        State GetConfirmed();
        State GetDiscarded();
        State GetPending();
    }
}
