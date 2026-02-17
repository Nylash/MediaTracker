using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IMediaEntryRepository
{
    MediaEntry? GetById(Guid id);
}
