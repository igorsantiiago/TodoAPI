using TodoApp.Domain.Entities;
using TodoApp.Domain.Queries;

namespace TodoApp.Domain.Tests.QueryTests;

[TestClass]
public class TodoItemQueryTests
{
    private List<TodoItem> _items;

    public TodoItemQueryTests()
    {
        _items = new List<TodoItem>
        {
            new TodoItem("Tarefa 01", DateTime.Now, "david"),
            new TodoItem("Tarefa 02", DateTime.Now, "david"),
            new TodoItem("Tarefa 01", DateTime.Now, "baltieri"),
            new TodoItem("Tarefa 03", DateTime.Now, "david"),
            new TodoItem("Tarefa 02", DateTime.Now, "baltieri")
        };
    }
    [TestMethod]
    public void Should_return_all_items_from_user_baltieri()
    {
        var result = _items.AsQueryable().Where(TodoItemQueries.GetAll("baltieri"));
        Assert.AreEqual(2, result.Count());
    }
}