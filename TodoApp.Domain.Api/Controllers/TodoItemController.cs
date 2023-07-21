using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Api.Controllers;

[ApiController]
[Route("v1/todo")]
// [Authorize]
public class TodoItemController : ControllerBase
{
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetAll(user);
        return repository.GetAll("Baltieri");
    }

    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetAllDone(user);
        return repository.GetAllDone("Baltieri");
    }

    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetAllUndone(user);
        return repository.GetAllUndone("Baltieri");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetDoneForToday(user);
        return repository.GetByPeriod("Baltieri", DateTime.Now.Date, true);
    }

    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetUndoneForToday(user);
        return repository.GetByPeriod("Baltieri", DateTime.Now.Date, false);
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetDoneForTomorrow(user);
        return repository.GetByPeriod("Baltieri", DateTime.Now.Date.AddDays(1), true);
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
    {
        //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        //return repository.GetUndoneForTomorrow(user);
        return repository.GetByPeriod("Baltieri", DateTime.Now.Date.AddDays(1), false);
    }

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
    {
        //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = "Baltieri";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("")]
    [HttpPut]
    public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
    {
        //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = "Baltieri";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
    {
        //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = "Baltieri";
        return (GenericCommandResult)handler.Handle(command);
    }

    [Route("mark-as-undone")]
    [HttpPut]
    public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
    {
        //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = "Baltieri";
        return (GenericCommandResult)handler.Handle(command);
    }
}