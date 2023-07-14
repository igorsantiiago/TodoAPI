using Flunt.Notifications;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Commands.Contracts;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers.Contracts;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Handlers;

public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oooops, parece que algo de errado foi inserido na atualização da tarefa.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);
        todo.UpdateTitle(command.Title);
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", DateTime.UtcNow);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oooops, parece que não foi possivel marcar tarefa como concluída.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);
        todo.MarkAsDone();
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa Concluída!", DateTime.UtcNow);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Oooops, parece que não foi possivel marcar tarefa como não concluída.", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);
        todo.MarkAsUndone();
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa marcada como não concluída!", DateTime.UtcNow);
    }
}
