using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IUserListRepository
{
    UserList? GetById(Guid id);
    void Add(UserList list);
    IEnumerable<UserList> GetByUserId(Guid userId);
    void Delete(Guid id);

}
