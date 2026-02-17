using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Repositories;

namespace MediaTracker.Domain.Services;

public class UserListService
{
    private readonly IUserListRepository _userListRepository;
    private readonly IMediaEntryRepository _mediaEntryRepository;

    public UserListService(
        IUserListRepository userListRepository,
        IMediaEntryRepository mediaEntryRepository)
    {
        _userListRepository = userListRepository;
        _mediaEntryRepository = mediaEntryRepository;
    }

    public UserListItem AddMediaToList(Guid listId, Guid mediaEntryId)
    {
        UserList list = _userListRepository.GetById(listId)
                   ?? throw new Exception("List not found");

        MediaEntry mediaEntry = _mediaEntryRepository.GetById(mediaEntryId)
                         ?? throw new Exception("MediaEntry not found");

        if (list.UserId != mediaEntry.UserId)
            throw new Exception("Cannot add media from another user");

        return new UserListItem(listId, mediaEntryId);
    }
}
