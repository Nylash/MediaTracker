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

    public MediaEntry? Get(Guid id)
    {
        return _context.MediaEntries.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<MediaEntry> GetAll()
    {
        return _context.MediaEntries.ToList();
    }

    public void Add(MediaEntry mediaEntry)
    {
        _context.MediaEntries.Add(mediaEntry);
        _context.SaveChanges();
    }

    public MediaEntry? GetByUserAndMedia(Guid userId, Guid mediaId)
    {
        return _context.MediaEntries
            .FirstOrDefault(x => x.UserId == userId && x.MediaId == mediaId);
    }
}
