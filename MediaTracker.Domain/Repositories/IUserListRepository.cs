using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IUserListRepository
{
    UserList? GetById(Guid id);
}
