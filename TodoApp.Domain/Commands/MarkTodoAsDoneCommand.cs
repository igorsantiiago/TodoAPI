using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands.Contracts;

namespace TodoApp.Domain.Commands;

public class MarkTodoAsDoneCommand : Notifiable, ICommand
{
    public MarkTodoAsDoneCommand() { }
    public MarkTodoAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract().Requires()
            .HasMinLen(User, 6, "User", "Usuário inválido!"));
    }
}