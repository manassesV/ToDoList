namespace ToDoList.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class TodoTaskController : BaseController<CreateTodoTaskCommand, TodoTaskServices, Result>
{
    public TodoTaskController(ILogger<TodoTaskController> logger, IMediator mediator) : base(logger, mediator) { }

    /// <summary>
    /// Creates a new TodoTask
    /// </summary>
    /// <typeparam name="CreateTodoTaskCommand"></typeparam>
    /// <param name="commmand"></param>
    /// <param name="services"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(ActionResult<Result>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(201, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpPost]
    [MapToApiVersion("1.0")]
    public override async Task<ActionResult<Result>> Add([FromBody] CreateTodoTaskCommand commmand, 
        [FromServices] TodoTaskServices services, CancellationToken cancellationToken)
    {
        var saveResult = await _mediator.Send(commmand, cancellationToken);

        return CreatedAtAction("Add", saveResult);
    }

    /// <summary>
    /// Finds all TodoTasks
    /// </summary>
    /// <param name="services"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResult<Result>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpGet]
    [MapToApiVersion("1.0")]
    public override async Task<ActionResult<Result>> FindAllAsync([FromServices] TodoTaskServices services, CancellationToken cancellationToken)
    {
        var todoTasks = await services._queries.FindAllAsync(cancellationToken);

        return Ok(todoTasks);
    }

    /// <summary>
    /// Finds a TodoTask by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="services"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResult<Result>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpGet("{Id}")]
    [MapToApiVersion("1.0")]
    public override async Task<ActionResult<Result>> FindByIdAsync(int Id, [FromServices] TodoTaskServices services, CancellationToken cancellationToken)
    {
        var todoTask = await services._queries.FindByIdAsync(Id, cancellationToken);

        return Ok(todoTask);
    }

    /// <summary>
    /// Updates a TodoTask
    /// </summary>
    /// <typeparam name="UpdateTodoTaskCommand"></typeparam>
    /// <param name="commmand"></param>
    /// <param name="services"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [Consumes("application/json")]
    [HttpPut("{Id}")]
    [MapToApiVersion("1.0")]
    public override async Task<ActionResult<Result>> Update(int Id, [FromBody] CreateTodoTaskCommand commmand, [FromServices] TodoTaskServices services, CancellationToken cancellationToken)
    {
        var updateCommand = new UpdateTodoTaskCommand(Id, commmand.Name, commmand.Description, commmand.DueDate, commmand.Status);

        var updateResult = await _mediator.Send(updateCommand, cancellationToken);

        return Ok(updateResult);
    }


    /// <summary>
    /// Deletes a TodoTask
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="services"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Produces("application/json")]
    [ProducesResponseType(typeof(ActionResult<Result>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [HttpGet("{Id}")]
    [MapToApiVersion("1.0")]
    public override async Task<ActionResult<Result>> Delete(int Id, [FromServices] TodoTaskServices services, CancellationToken cancellationToken)
    {
        var deleteCommand = new DeleteTodoTaskCommand(Id);


        var deleteResult = await _mediator.Send(deleteCommand, cancellationToken);

        return Ok(deleteResult);
    }
}
