using Microsoft.EntityFrameworkCore;
using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Infrastructure.Data;

public class GreenLoopDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }

    public GreenLoopDbContext(DbContextOptions<GreenLoopDbContext> options) : base(options) { }
}