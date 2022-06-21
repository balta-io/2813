using Blog.Core.Entities;
using Blog.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext
{
    public BlogDataContext(DbContextOptions<BlogDataContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PostMap());
        modelBuilder.ApplyConfiguration(new TagMap());
        modelBuilder.ApplyConfiguration(new TagMap());
    }
}