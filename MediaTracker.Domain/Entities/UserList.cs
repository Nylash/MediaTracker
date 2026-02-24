using MediaTracker.Domain.Enums;

namespace MediaTracker.Domain.Entities;

public class UserList
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }

    public string ListName { get; private set; }

    public bool IsDefault { get; private set; }

    public MediaCategory? Category { get; private set; }

    private UserList() { }

    // Constructeur pour liste par défaut
    public UserList(Guid userId, MediaCategory category)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Category = category;
        IsDefault = true;
        ListName = category.ToString();
    }

    // Constructeur pour liste custom
    public UserList(Guid userId, string listName)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ListName = listName;
        IsDefault = false;
        Category = null;
    }

    public void Rename(string newName)
    {
        if (IsDefault)
            throw new InvalidOperationException("Default lists cannot be renamed.");

        ListName = newName;
    }
}