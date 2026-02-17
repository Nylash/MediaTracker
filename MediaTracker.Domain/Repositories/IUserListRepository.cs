using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IUserListRepository
{
    UserList? Get(Guid id);
    void Add(UserList list);
    IEnumerable<UserList> GetAll(Guid userId);
    void Delete(Guid id);
    UserList? GetByUserAndName(Guid userId, string listName);

}
