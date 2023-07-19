using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Entities.Data.Mappings;

namespace TodoApp.Domain.Infra.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoItemMap());
    }
}