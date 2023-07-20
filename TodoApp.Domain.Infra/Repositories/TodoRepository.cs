using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Infra.Data;
using TodoApp.Domain.Queries;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }
    public void Create(TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user) => _context.TodoItems.AsNoTracking().Where(TodoItemQueries.GetAll(user)).OrderBy(x => x.Date);

    public IEnumerable<TodoItem> GetAllDone(string user) => _context.TodoItems.AsNoTracking().Where(TodoItemQueries.GetAllDone(user)).OrderBy(x => x.Date);

    public IEnumerable<TodoItem> GetAllUndone(string user) => _context.TodoItems.AsNoTracking().Where(TodoItemQueries.GetAllUndone(user)).OrderBy(x => x.Date);

    public TodoItem GetById(Guid id, string user) => _context.TodoItems.FirstOrDefault(TodoItemQueries.GetById(id, user));

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done) => _context.TodoItems.AsNoTracking().Where(TodoItemQueries.GetByPeriod(user, date, done)).OrderBy(x => x.Date);

    public void Update(TodoItem todoItem)
    {
        _context.Entry(todoItem).State = EntityState.Modified;
        _context.SaveChanges();
    }
}