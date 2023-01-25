using Microsoft.EntityFrameworkCore;
using ModsenTask.Models;

namespace ModsenTask.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }

    public DbSet<Speaker> Speakers { get; set; }

    public DbSet<Organizer> Organizers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Speaker)
            .WithMany(s => s.Events)
            .HasForeignKey(e => e.SpeakerId);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany(u => u.Events)
            .HasForeignKey(e => e.OrganizerId);
    }
}