using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Repositories;
using MediaTracker.Infrastructure.Persistence;

namespace MediaTracker.Infrastructure.Repositories;

public class MediaRepository : IMediaRepository
{
    private readonly MediaTrackerDbContext _context;

    public MediaRepository(MediaTrackerDbContext context)
    {
        _context = context;
    }

    public Media? Get(Guid id)
    {
        return _context.Media.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Media> GetAll()
    {
        return _context.Media.ToList();
    }

    public void Add(Media media)
    {
        _context.Media.Add(media);
        _context.SaveChanges();
    }

    public Media? GetByTitleAndCategory(string title, MediaCategory category)
    {
        return _context.Media
            .FirstOrDefault(m => m.Title == title && m.Category == category);
    }
}
