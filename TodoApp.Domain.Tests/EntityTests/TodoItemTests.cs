using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _validTodo = new("Titulo ToDo", DateTime.UtcNow, "Baltieri");

    [TestMethod]
    public void Given_a_new_ToDo_task_it_cannot_be_completed() => Assert.AreEqual(_validTodo.Done, false);
}