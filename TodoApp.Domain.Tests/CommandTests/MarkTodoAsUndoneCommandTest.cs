using TodoApp.Domain.Commands;

namespace TodoApp.Domain.Tests.CommandTests;

[TestClass]
public class MarkTodoAsUndoneCommandTest
{
    private readonly MarkTodoAsDoneCommand _validCommand = new(Guid.NewGuid(), "Baltieri");
    private readonly MarkTodoAsDoneCommand _invalidUserCommand = new(Guid.NewGuid(), "User");
    private readonly MarkTodoAsDoneCommand _nullUserCommand = new(Guid.NewGuid(), null!);

    public MarkTodoAsUndoneCommandTest()
    {
        _validCommand.Validate();
        _invalidUserCommand.Validate();
        _nullUserCommand.Validate();
    }

    [TestMethod]
    public void Should_return_valid_when_all_properties_are_correct() => Assert.AreEqual(_validCommand.Valid, true);

    [TestMethod]
    public void Should_return_invalid_when_user_has_less_then_six_characters() => Assert.AreEqual(_invalidUserCommand.Valid, false);

    [TestMethod]
    public void Should_return_invalid_when_user_is_null() => Assert.AreEqual(_nullUserCommand.Valid, false);
}
