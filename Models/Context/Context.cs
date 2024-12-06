using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<WorkCategory> WorkCategories_tbl { get; set; }
    public DbSet<WorkPC> WorkPC_tbl { get; set; }
    public DbSet<WorkPost> WorkPosts_tbl { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.\\SQL2019;database=Xinosazeh;user ID=sa;password=1234;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
}