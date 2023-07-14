using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todoItem) { }

    public void Update(TodoItem todoItem) { }

    public TodoItem GetById(Guid id, string user) => new("Titulo", DateTime.UtcNow, "Baltieri");
}
