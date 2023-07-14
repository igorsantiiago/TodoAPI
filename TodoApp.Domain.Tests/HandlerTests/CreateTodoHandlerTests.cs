using TodoApp.Domain.Commands;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Tests.Repositories;

namespace TodoApp.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand = new("", "", DateTime.UtcNow);
    private readonly CreateTodoCommand _validCommand = new("Adicionar tarefa", "Baltieri", DateTime.UtcNow);
    private readonly TodoHandler _handler = new(new FakeTodoRepository());

    public CreateTodoHandlerTests() { }

    [TestMethod]
    public void Given_an_invalid_command_execution_should_be_interrupted()
    {
        var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Given_a_valid_command_should_create_task()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}