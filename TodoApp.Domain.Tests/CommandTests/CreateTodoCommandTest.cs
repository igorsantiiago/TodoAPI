using TodoApp.Domain.Commands;

namespace TodoApp.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTest
{
    private readonly CreateTodoCommand _invalidCommand = new("", "", DateTime.UtcNow);
    private readonly CreateTodoCommand _validCommand = new("Adicionar tarefa", "Baltieri", DateTime.UtcNow);

    public CreateTodoCommandTest()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Given_an_invalid_command() => Assert.AreEqual(_invalidCommand.Valid, false);

    [TestMethod]
    public void Given_an_valid_command() => Assert.AreEqual(_validCommand.Valid, true);
}