namespace MediaTracker.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Username { get; private set; }

    public string Email { get; private set; }

    private User() { }

    public User(string username, string email)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
    }

    public void ChangeUsername(string newUsername)
    {
        Username = newUsername;
    }

    public void ChangeEmail(string newEmail)
    {
        Email = newEmail;
    }
}
