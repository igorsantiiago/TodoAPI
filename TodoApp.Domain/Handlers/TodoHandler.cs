using Flunt.Notifications;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Commands.Contracts;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers.Contracts;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Handlers;

public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }
    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validate();

        if (command.Invalid)
            return new GenericCommandResult(false, "Oooops, parece que algo de errado foi inserido na criação da tarefa.", command.Notifications);

        var todo = new TodoItem(command.Title, command.Date, command.User);
        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa cadastrada com sucesso!", todo);
    }
}
