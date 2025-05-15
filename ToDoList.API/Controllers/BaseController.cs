namespace ToDoList.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public abstract class BaseController<TCommand, TServices, TResult>: ControllerBase
    where TResult : class
    where TServices : class
{
    protected readonly ILogger<BaseController<TCommand, TServices, TResult>> _logger;
    protected readonly IMediator _mediator;

    protected BaseController(ILogger<BaseController<TCommand, TServices, TResult>> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public abstract Task<ActionResult<TResult>> Add(
        [FromBody] TCommand commmand,
        [FromServices] TServices services,
        CancellationToken cancellationToken);
    public abstract Task<ActionResult<TResult>> FindAllAsync(
        [FromServices] TServices services,
        CancellationToken cancellationToken);
    public abstract Task<ActionResult<TResult>> FindByIdAsync(int id,
        [FromServices] TServices services,
        CancellationToken cancellationToken);
    public abstract Task<ActionResult<TResult>> Update(
        int Id,
        [FromBody] TCommand commmand,
        [FromServices] TServices services,
        CancellationToken cancellationToken);
}
