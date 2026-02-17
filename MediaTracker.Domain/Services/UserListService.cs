using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Repositories;

namespace MediaTracker.Domain.Services;

public class UserListService
{
    private readonly IUserListRepository _userListRepository;

    public UserListService(
        IUserListRepository userListRepository,
        IMediaEntryRepository mediaEntryRepository)
    {
        _userListRepository = userListRepository;
    }

    public void CreateList(Guid userId, string listName)
    {
        UserList? list = new UserList(userId, listName);

        _userListRepository.Add(list);
    }

    public IEnumerable<UserList> GetUserLists(Guid userId)
    {
        return _userListRepository.GetAll(userId);
    }

    public void DeleteList(Guid id)
    {
        _userListRepository.Delete(id);
    }
}
