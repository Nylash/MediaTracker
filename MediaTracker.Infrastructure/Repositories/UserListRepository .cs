using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Repositories;
using MediaTracker.Infrastructure.Persistence;

namespace MediaTracker.Infrastructure.Repositories;

public class UserListRepository : IUserListRepository
{
    private readonly MediaTrackerDbContext _context;

    public UserListRepository(MediaTrackerDbContext context)
    {
        _context = context;
    }

    public UserList? Get(Guid id)
    {
        return _context.UserLists.FirstOrDefault(x => x.Id == id);
    }

    public void Add(UserList list)
    {
        _context.UserLists.Add(list);
        _context.SaveChanges();
    }

    public IEnumerable<UserList> GetAll(Guid userId)
    {
        return _context.UserLists
                       .Where(x => x.UserId == userId)
                       .ToList();
    }

    public void Delete(Guid id)
    {
        UserList? list = _context.UserLists.FirstOrDefault(x => x.Id == id);
        if (list != null)
        {
            _context.UserLists.Remove(list);
            _context.SaveChanges();
        }
    }
    public UserList? GetByUserAndName(Guid userId, string listName)
    {
        return _context.UserLists
            .FirstOrDefault(l => l.UserId == userId && l.ListName == listName);
    }
}
