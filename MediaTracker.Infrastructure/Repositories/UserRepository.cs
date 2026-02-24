using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Repositories;
using MediaTracker.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly MediaTrackerDbContext _context;

    public UserRepository(MediaTrackerDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User? Get(Guid id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }
}