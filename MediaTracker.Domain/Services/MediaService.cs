using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Enums;
using MediaTracker.Domain.Exceptions;
using MediaTracker.Domain.Repositories;

namespace MediaTracker.Domain.Services;

public class MediaService
{
    private const int MAX_TITLE_LENGTH = 64;

    private readonly IMediaRepository _mediaRepository;

    public MediaService(IMediaRepository mediaRepository)
    {
        _mediaRepository = mediaRepository;
    }

    public Media CreateMedia(string title, MediaCategory category)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new BusinessRuleException("Title cannot be empty");

        if (title.Length > MAX_TITLE_LENGTH)
            throw new BusinessRuleException($"Title cannot exceed {MAX_TITLE_LENGTH} characters");

        Media? existing = _mediaRepository.GetByTitleAndCategory(title.Trim(), category);
        if (existing != null)
            throw new BusinessRuleException("Media already exists");

        Media media = new Media(title.Trim(), category);
        _mediaRepository.Add(media);

        return media;
    }

    public IEnumerable<Media> GetAll()
    {
        return _mediaRepository.GetAll();
    }
}
