using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<WorkCategory> WorkCategories_tbl { get; set; }
    public DbSet<WorkPC> WorkPC_tbl { get; set; }
    public DbSet<WorkPost> WorkPosts_tbl { get; set; }

    public DbSet<blogComment> BlogComments_tbl { get; set; }
    public DbSet<blogPost> BlogPost_tbl { get; set; }

    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
}