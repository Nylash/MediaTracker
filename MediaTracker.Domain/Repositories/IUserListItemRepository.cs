using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public  interface IUserListItemRepository
{
    void Add(UserListItem item);
    IEnumerable<UserListItem> GetAll(Guid listId);
    UserListItem? Get(Guid listId, Guid mediaEntryId);
    void Remove(UserListItem item);

}
