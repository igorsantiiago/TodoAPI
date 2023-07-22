using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;
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

    [MinLength(6)]
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract().Requires()
            .HasMinLen(User, 6, "User", "Usuário inválido!"));
    }
}
