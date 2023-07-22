using TodoApp.Domain.Commands;

namespace TodoApp.Domain.Tests.CommandTests;

[TestClass]
public class UpdateTodoCommandTest
{
    private readonly UpdateTodoCommand _validCommand = new(Guid.NewGuid(), "Valid Title", "Baltieri");
    private readonly UpdateTodoCommand _invalidTitleCommand = new(Guid.NewGuid(), "", "Baltieri");
    private readonly UpdateTodoCommand _invalidNullTitleCommand = new(Guid.NewGuid(), null!, "Baltieri");
    private readonly UpdateTodoCommand _invalidUserCommand = new(Guid.NewGuid(), "Valid Title", "");
    private readonly UpdateTodoCommand _invalidNullUserCommand = new(Guid.NewGuid(), "Valid Title", null!);

    public UpdateTodoCommandTest()
    {
        _validCommand.Validate();
        _invalidTitleCommand.Validate();
        _invalidNullTitleCommand.Validate();
        _invalidUserCommand.Validate();
        _invalidNullUserCommand.Validate();
    }

    [TestMethod]
    public void Should_return_valid_when_all_properties_are_correct() => Assert.AreEqual(_validCommand.Valid, true);

    [TestMethod]
    public void Should_return_invalid_when_title_has_less_than_three_characters() => Assert.AreEqual(_invalidTitleCommand.Valid, false);

    [TestMethod]
    public void Should_return_invalid_when_title_is_null() => Assert.AreEqual(_invalidNullTitleCommand.Valid, false);

    [TestMethod]
    public void Should_return_invalid_when_user_has_less_than_six_characters() => Assert.AreEqual(_invalidUserCommand.Valid, false);

    [TestMethod]
    public void Should_return_invalid_when_user_is_null() => Assert.AreEqual(_invalidNullUserCommand.Valid, false);
}
