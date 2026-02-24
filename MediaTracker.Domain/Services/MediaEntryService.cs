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

    public EntryDeletionInfo GetDeletionInfo(Guid mediaEntryId)
    {
        var entry = _mediaEntryRepository.Get(mediaEntryId)
            ?? throw new NotFoundException("Entry not found");

        var listItems = _userListItemRepository
            .GetAllByEntry(mediaEntryId);

        var customCount = listItems.Count(li =>
        {
            var list = _userListRepository.Get(li.ListId);
            return list != null && !list.IsDefault;
        });

        return new EntryDeletionInfo
        {
            TotalLists = listItems.Count(),
            CustomLists = customCount
        };
    }

    public void Delete(Guid mediaEntryId)
    {
        var entry = _mediaEntryRepository.Get(mediaEntryId)
            ?? throw new NotFoundException("Entry not found");

        var listItems = _userListItemRepository
            .GetAllByEntry(mediaEntryId);

        foreach (var item in listItems)
            _userListItemRepository.Remove(item);

        _mediaEntryRepository.Remove(entry);
    }
}