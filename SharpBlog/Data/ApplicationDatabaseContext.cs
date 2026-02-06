using Microsoft.EntityFrameworkCore;

namespace SharpBlog.Data;

public class ApplicationDatabaseContext : DbContext
{
  public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
  {
  }

  public DbSet<Models.Post> Posts { get; set; }
  public DbSet<Models.Category> Categories { get; set; }
  public DbSet<Models.Comment> Comments { get; set; }
}
