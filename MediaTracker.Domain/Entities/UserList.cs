namespace MediaTracker.Domain.Entities;

public class UserList
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string Name { get; private set; }

    private UserList() { }

    public UserList(Guid userId, string name)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
    }

    public void Rename(string newName)
    {
        Name = newName;
    }
}
