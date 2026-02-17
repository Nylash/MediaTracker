using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;

namespace MediaTracker.Domain.Repositories;

public interface IMediaRepository
{
    Media? Get(Guid id);
    void Add(Media media);
    IEnumerable<Media> GetAll();
    Media? GetByTitleAndCategory(string title, MediaCategory category);
}
