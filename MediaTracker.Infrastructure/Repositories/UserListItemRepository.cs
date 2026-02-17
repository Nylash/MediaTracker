using MediaTracker.Domain.Entities;
using MediaTracker.Domain.Repositories;
using MediaTracker.Infrastructure.Persistence;

namespace MediaTracker.Infrastructure.Repositories;

public class UserListItemRepository : IUserListItemRepository
{
    private readonly MediaTrackerDbContext _context;

    public UserListItemRepository(MediaTrackerDbContext context)
    {
        _context = context;
    }

    public void Add(UserListItem item)
    {
        _context.UserListItems.Add(item);
        _context.SaveChanges();
    }

    public IEnumerable<UserListItem> GetAll(Guid listId)
    {
        return _context.UserListItems
            .Where(x => x.ListId == listId)
            .ToList();
    }

    public UserListItem? Get(Guid listId, Guid mediaId)
    {
        return _context.UserListItems
            .FirstOrDefault(x => x.ListId == listId && x.MediaEntryId == mediaId);
    }

    public void Remove(UserListItem item)
    {
        _context.UserListItems.Remove(item);
        _context.SaveChanges();
    }
}
