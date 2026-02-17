using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Repositories;

namespace MediaTracker.Domain.Services;

public class MediaService
{
    private readonly IMediaRepository _mediaRepository;

    public MediaService(IMediaRepository mediaRepository)
    {
        _mediaRepository = mediaRepository;
    }

    public Media CreateMedia(string title, MediaCategory category)
    {
        Media? media = new Media(title, category);
        _mediaRepository.Add(media);
        return media;
    }

    public IEnumerable<Media> GetAll()
    {
        return _mediaRepository.GetAll();
    }
}
