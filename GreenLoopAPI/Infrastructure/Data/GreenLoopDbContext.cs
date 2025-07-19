using GreenLoopAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenLoopAPI.Infrastructure.Data;

public class GreenLoopDbContext : DbContext
{
    public GreenLoopDbContext(DbContextOptions<GreenLoopDbContext> options) : base(options) {}
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventAttendance> EventAttendances { get; set; }
}