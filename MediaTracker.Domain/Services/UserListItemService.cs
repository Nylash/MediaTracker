using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Exceptions;
using MediaTracker.Domain.Repositories;

namespace MediaTracker.Domain.Services;

public class UserListItemService
{
    private readonly IUserListItemRepository _userListItemRepository;
    private readonly IUserListRepository _userListRepository;
    private readonly IMediaRepository _mediaRepository;
    private readonly IMediaEntryRepository _mediaEntryRepository;

    public UserListItemService(
        IUserListItemRepository userListItemRepository,
        IUserListRepository userListRepository,
        IMediaRepository mediaRepository,
        IMediaEntryRepository mediaEntryRepository)
    {
        _userListItemRepository = userListItemRepository;
        _userListRepository = userListRepository;
        _mediaRepository = mediaRepository;
        _mediaEntryRepository = mediaEntryRepository;
    }

    public void AddMediaEntryToList(Guid listId, Guid mediaEntryId)
    {
        if (listId == Guid.Empty)
            throw new BusinessRuleException("Invalid list id");

        if (mediaEntryId == Guid.Empty)
            throw new BusinessRuleException("Invalid media entry id");

        var list = _userListRepository.Get(listId)
            ?? throw new NotFoundException("List not found");

        var entry = _mediaEntryRepository.Get(mediaEntryId)
            ?? throw new NotFoundException("Media entry not found");

        if (entry.UserId != list.UserId)
            throw new BusinessRuleException("Entry does not belong to this user");

        var existing = _userListItemRepository.Get(listId, mediaEntryId);
        if (existing != null)
            throw new BusinessRuleException("Item already in list");

        var item = new UserListItem(listId, mediaEntryId);
        _userListItemRepository.Add(item);
    }

    public IEnumerable<UserListItem> GetListItems(Guid listId)
    {
        if (listId == Guid.Empty)
            throw new BusinessRuleException("Invalid list id");

        UserList? list = _userListRepository.Get(listId);
        if (list == null)
            throw new NotFoundException("List not found");

        return _userListItemRepository.GetAll(listId);
    }

    public void RemoveMediaFromList(Guid listId, Guid mediaId)
    {
        if (listId == Guid.Empty)
            throw new BusinessRuleException("Invalid list id");

        if (mediaId == Guid.Empty)
            throw new BusinessRuleException("Invalid media id");

        UserListItem? item = _userListItemRepository.Get(listId, mediaId);
        if (item == null)
            throw new NotFoundException("Item not found");

        _userListItemRepository.Remove(item);
    }
}
