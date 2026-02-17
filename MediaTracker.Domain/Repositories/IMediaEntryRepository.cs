using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IMediaEntryRepository
{
    MediaEntry? Get(Guid id);
    void Add(MediaEntry mediaEntry);
    IEnumerable<MediaEntry> GetAll();
    MediaEntry? GetByUserAndMedia(Guid userId, Guid mediaId);

}
