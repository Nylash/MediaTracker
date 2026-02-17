using MediaTracker.Domain.Enums;

namespace MediaTracker.Domain.Entities;

public class Media
{
    public Guid Id { get; private set; }

    public string? Title { get; private set; }

    public MediaCategory Category { get; private set; }

    private Media() { }

    public Media(string title, MediaCategory category)
    {
        Id = Guid.NewGuid();
        Title = title;
        Category = category;
    }
}
