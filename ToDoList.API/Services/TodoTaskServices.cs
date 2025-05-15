namespace ToDoList.API.Services;

public class TodoTaskServices(IMediator mediator,
    ITodoTaskQueries queries,
    ILogger<TodoTaskServices> logger)
{
    public IMediator _mediator { get; set; } = mediator;
    public ITodoTaskQueries _queries { get; set; } = queries;
    public ILogger<TodoTaskServices> _logger { get; set; } = logger;

}
