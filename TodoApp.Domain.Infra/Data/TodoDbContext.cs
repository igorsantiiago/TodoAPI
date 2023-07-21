
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Infra.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
        modelBuilder.Entity<TodoItem>().Property(x => x.Id);
        modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
        modelBuilder.Entity<TodoItem>().Property(x => x.Title).IsRequired().HasMaxLength(160).HasColumnType("varchar(160)");
        modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
        modelBuilder.Entity<TodoItem>().Property(x => x.Date);
        modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
    }
}