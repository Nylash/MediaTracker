using Microsoft.EntityFrameworkCore;
using MediaTracker.Domain.Entities;

namespace MediaTracker.Infrastructure.Persistence;

public class MediaTrackerDbContext : DbContext
{
    public MediaTrackerDbContext(DbContextOptions<MediaTrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Media> Media => Set<Media>();
    public DbSet<MediaEntry> MediaEntries => Set<MediaEntry>();
    public DbSet<UserList> UserLists => Set<UserList>();
    public DbSet<UserListItem> UserListItems => Set<UserListItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Contrainte unique métier
        modelBuilder.Entity<MediaEntry>()
            .HasIndex(x => new { x.UserId, x.MediaId })
            .IsUnique();
    }
}
