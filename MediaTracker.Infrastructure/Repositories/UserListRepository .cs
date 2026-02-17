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

    public UserList? GetById(Guid id)
    {
        return _context.UserLists.FirstOrDefault(x => x.Id == id);
    }
}
