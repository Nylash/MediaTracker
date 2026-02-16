namespace MediaTracker.Domain.Entities;

public class UserListItem
{
    public Guid Id { get; private set; }

    public Guid ListId { get; private set; }

    public Guid MediaEntryId { get; private set; }

    private UserListItem() { }

    public UserListItem(Guid listId, Guid mediaEntryId)
    {
        Id = Guid.NewGuid();
        ListId = listId;
        MediaEntryId = mediaEntryId;
    }
}
