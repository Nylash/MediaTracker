using MediaTracker.Domain.Entities;
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

    public void AddMediaToList(Guid listId, Guid mediaId)
    {
        UserList? list = _userListRepository.Get(listId);
        if (list == null)
            throw new Exception("List not found");

        Media? media = _mediaRepository.Get(mediaId);
        if (media == null)
            throw new Exception("Media not found");

        MediaEntry? mediaEntry = _mediaEntryRepository.GetByUserAndMedia(list.UserId, mediaId);
        if (mediaEntry == null)
        {
            mediaEntry = new MediaEntry(list.UserId, mediaId);
            _mediaEntryRepository.Add(mediaEntry);
        }

        UserListItem? existing = _userListItemRepository.Get(listId, mediaEntry.Id);
        if (existing != null)
            throw new Exception("Item already in list");


        UserListItem item = new UserListItem(listId, mediaEntry.Id);
        _userListItemRepository.Add(item);
    }

    public IEnumerable<UserListItem> GetListItems(Guid listId)
    {
        UserList? list = _userListRepository.Get(listId);
        if (list == null)
            throw new Exception("List not found");

        return _userListItemRepository.GetAll(listId);
    }

    public void RemoveMediaFromList(Guid listId, Guid mediaId)
    {
        UserListItem? item = _userListItemRepository.Get(listId, mediaId);
        if (item == null)
            throw new Exception("Item not found");

        _userListItemRepository.Remove(item);
    }
}
