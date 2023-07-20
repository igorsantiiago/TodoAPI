using System.Linq.Expressions;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Queries;

public static class TodoItemQueries
{
    public static Expression<Func<TodoItem, bool>> GetAll(string user) => x => x.User == user;
    public static Expression<Func<TodoItem, bool>> GetAllDone(string user) => x => x.User == user && x.Done == true;
    public static Expression<Func<TodoItem, bool>> GetAllUndone(string user) => x => x.User == user && x.Done == false;
    public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done) =>
        x => x.User == user &&
        x.Date.Date == date.Date &&
        x.Done == done;
    public static Expression<Func<TodoItem, bool>> GetById(Guid id, string user) => x => x.Id == id && x.User == user;
}