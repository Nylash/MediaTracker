using MediaTracker.Domain.Enums;

namespace MediaTracker.Domain.Entities;

public class MediaEntry
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public Guid MediaId { get; private set; }

    public MediaStatus Status { get; private set; }

    public string? Note { get; private set; }

    private MediaEntry() { }

    public MediaEntry(Guid userId, Guid mediaId, MediaStatus? status = null)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        MediaId = mediaId;
        Status = status ?? MediaStatus.Planned;
    }

    public void ChangeStatus(MediaStatus newStatus)
    {
        Status = newStatus;
    }

    public void UpdateNote(string note)
    {
        Note = note;
    }
}
