using MediaTracker.Domain.Entities;

namespace MediaTracker.Domain.Repositories;

public interface IMediaRepository
{
    Media? Get(Guid id);
    void Add(Media media);
    IEnumerable<Media> GetAll();
}
