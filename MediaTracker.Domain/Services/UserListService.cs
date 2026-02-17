using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Exceptions;
using MediaTracker.Domain.Repositories;

namespace MediaTracker.Domain.Services;

public class UserListService
{
    private const int MAX_LIST_NAME_LENGTH = 64;

    private readonly IUserListRepository _userListRepository;

    public UserListService(
        IUserListRepository userListRepository,
        IMediaEntryRepository mediaEntryRepository)
    {
        _userListRepository = userListRepository;
    }

    public void CreateList(Guid userId, string listName)
    {
        if (userId == Guid.Empty)
            throw new BusinessRuleException("Invalid user id");

        if (string.IsNullOrWhiteSpace(listName))
            throw new BusinessRuleException("List name cannot be empty");

        if (listName.Length > MAX_LIST_NAME_LENGTH)
            throw new BusinessRuleException($"List name cannot exceed {MAX_LIST_NAME_LENGTH} characters");

        var existing = _userListRepository.GetByUserAndName(userId, listName.Trim());
        if (existing != null)
            throw new BusinessRuleException("A list with this name already exists");

        UserList list = new UserList(userId, listName.Trim());
        _userListRepository.Add(list);
    }

    public IEnumerable<UserList> GetUserLists(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new BusinessRuleException("Invalid user id");

        return _userListRepository.GetAll(userId);
    }

    public void DeleteList(Guid listId)
    {
        if (listId == Guid.Empty)
            throw new BusinessRuleException("Invalid list id");

        UserList? list = _userListRepository.Get(listId);
        if (list == null)
            throw new NotFoundException("List not found");

        _userListRepository.Delete(listId);
    }
}
