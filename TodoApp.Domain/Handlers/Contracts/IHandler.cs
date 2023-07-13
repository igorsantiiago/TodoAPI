using TodoApp.Domain.Commands.Contracts;

namespace TodoApp.Domain.Handlers.Contracts;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}