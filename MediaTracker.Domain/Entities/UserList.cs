namespace MediaTracker.Domain.Entities;

public class UserList
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string? ListName { get; private set; }

    private UserList() { }

    public UserList(Guid userId, string listName)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ListName = listName;
    }

    public void Rename(string newName)
    {
        ListName = newName;
    }
}
