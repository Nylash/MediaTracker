using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Exceptions;
using MediaTracker.Domain.Repositories;

public class MediaEntryService
{
    private readonly IMediaEntryRepository _mediaEntryRepository;
    private readonly IMediaRepository _mediaRepository;
    private readonly IUserListRepository _userListRepository;
    private readonly IUserListItemRepository _userListItemRepository;

    public MediaEntryService(
        IMediaEntryRepository repository , IMediaRepository mediaRepository, 
        IUserListRepository userListRepository, IUserListItemRepository userListItemRepository)
    {
        _mediaEntryRepository = repository;
        _mediaRepository = mediaRepository;
        _userListRepository = userListRepository;
        _userListItemRepository = userListItemRepository;
    }

    public MediaEntry? GetByMedia(Guid userId, Guid mediaId)
    {
        return _mediaEntryRepository.GetByUserAndMedia(userId, mediaId);
    }

    public MediaEntry Create(Guid userId, Guid mediaId, MediaStatus status)
    {
        var existing = _mediaEntryRepository.GetByUserAndMedia(userId, mediaId);
        if (existing != null)
            return existing;

        var entry = new MediaEntry(userId, mediaId, status);
        _mediaEntryRepository.Add(entry);

        var media = _mediaRepository.Get(mediaId);
        if (media == null)
            throw new NotFoundException("Media not found");

        var defaultList = _userListRepository
            .GetDefaultList(userId, media.Category);

        if (defaultList == null)
            throw new Exception("Default list not found");

        var listItem = new UserListItem(defaultList.Id, entry.Id);
        _userListItemRepository.Add(listItem);

        return entry;
    }

    public MediaEntry UpdateStatus(Guid id, MediaStatus status)
    {
        MediaEntry? entry = _mediaEntryRepository.Get(id);
        if (entry == null)
            throw new BusinessRuleException("Invalid mediaEntry id");
        entry.UpdateStatus(status);
        _mediaEntryRepository.SaveChanges(entry);
        return entry;
    }
}