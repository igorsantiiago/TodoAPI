using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ITodoRepository
{
    void Create(TodoItem todoItem);
    void Update(TodoItem todoItem);
    TodoItem GetById(Guid id, string user);
}