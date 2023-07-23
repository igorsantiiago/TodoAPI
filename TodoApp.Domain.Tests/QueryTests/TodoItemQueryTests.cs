using System.Data.Common;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Queries;

namespace TodoApp.Domain.Tests.QueryTests;

[TestClass]
public class TodoItemQueryTests
{
    private readonly List<TodoItem> _items;

    public TodoItemQueryTests()
    {
        _items = new List<TodoItem>
        {
            new TodoItem("Tarefa 01", DateTime.Now, "david"),
            new TodoItem("Tarefa 02", DateTime.Now, "david"),
            new TodoItem("Tarefa 01", DateTime.Now, "baltieri"),
            new TodoItem("Tarefa 03", DateTime.Now, "david"),
            new TodoItem("Tarefa 02", DateTime.Now, "baltieri"),
            new TodoItem("Tarefa 01", DateTime.Now.AddDays(100), "balta")
        };
        _items[0].MarkAsDone();
        _items[3].MarkAsDone();
    }

    [TestMethod]
    public void Should_return_all_items_from_user_baltieri()
    {
        var result = _items.AsQueryable().Where(TodoItemQueries.GetAll("baltieri"));
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void Should_return_items_set_as_done_from_user_david()
    {
        var result = _items.AsQueryable().Where(TodoItemQueries.GetAllDone("david"));
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void Should_return_items_set_as_undone_from_user_david()
    {
        var result = _items.AsQueryable().Where(TodoItemQueries.GetAllUndone("david"));
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Should_return_items_with_an_specific_date_from_user_balta()
    {
        var result = _items.AsQueryable().Where(TodoItemQueries.GetByPeriod("balta", DateTime.Now.AddDays(100), false));
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void Should_return_item_with_an_specific_id()
    {
        var id = _items[0].Id;

        var result = _items.AsQueryable().Where(TodoItemQueries.GetById(id, "david"));
        Assert.AreEqual(1, result.Count());
    }
}