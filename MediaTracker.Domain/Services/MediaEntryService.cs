using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Exceptions;
using MediaTracker.Domain.Repositories;

public class MediaEntryService
{
    private readonly IMediaEntryRepository _repository;

    public MediaEntryService(IMediaEntryRepository repository)
    {
        _repository = repository;
    }

    public MediaEntry? GetByMedia(Guid userId, Guid mediaId)
    {
        return _repository.GetByUserAndMedia(userId, mediaId);
    }

    public MediaEntry Create(Guid userId, Guid mediaId, MediaStatus status)
    {
        var existing = _repository.GetByUserAndMedia(userId, mediaId);
        if (existing != null)
            return existing;

        var entry = new MediaEntry(userId, mediaId, status);
        _repository.Add(entry);
        return entry;
    }

    public MediaEntry UpdateStatus(Guid id, MediaStatus status)
    {
        MediaEntry? entry = _repository.Get(id);
        if (entry == null)
            throw new BusinessRuleException("Invalid mediaEntry id");
        entry.UpdateStatus(status);
        _repository.SaveChanges(entry);
        return entry;
    }
}