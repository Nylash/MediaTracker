using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IUserRepository
{
    void Add(User user);
    User? Get(Guid id);
}
