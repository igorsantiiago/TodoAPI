using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Api.Controllers;

[ApiController]
[Route("v1/todo")]
public class TodoItemController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
    {
        return repository.GetAll("Baltieri");
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
    {
        command.User = "Baltieri";
        return (GenericCommandResult)handler.Handle(command);

    }
}