using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Repositories;
using MediaTracker.Infrastructure.Persistence;

namespace MediaTracker.Infrastructure.Repositories;

public class MediaEntryRepository : IMediaEntryRepository
{
    private readonly MediaTrackerDbContext _context;

    public MediaEntryRepository(MediaTrackerDbContext context)
    {
        _context = context;
    }

    public MediaEntry? GetById(Guid id)
    {
        return _context.MediaEntries.FirstOrDefault(x => x.Id == id);
    }
}
