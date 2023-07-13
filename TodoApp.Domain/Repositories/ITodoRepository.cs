using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ITodoRepository
{
    void Create(TodoItem todoItem);
    void Delete(TodoItem todoItem);
}