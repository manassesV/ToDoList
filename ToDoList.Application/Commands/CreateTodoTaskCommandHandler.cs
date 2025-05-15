namespace ToDoList.Application.Commands;

public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand, Result>
{
    private readonly ITodoTaskRepository _todoTaskRepository;
    private readonly ILogger<CreateTodoTaskCommandHandler> _logger;

    public CreateTodoTaskCommandHandler(ITodoTaskRepository todoTaskRepository,
        ILogger<CreateTodoTaskCommandHandler> logger)
    {
        _todoTaskRepository = todoTaskRepository;
        _logger = logger;
    }
    public async Task<Result> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todoTask = new TodoTask(request.Name, request.Description, request.DueDate);
            todoTask.Pending();

            if (!todoTask.isValid())
            {
                _logger.LogError("TodoTask {Name} is not valid", request.Name);
                var errorMessages = string.Join("; ", todoTask.ValidationResult.Errors.Select(e => e.ErrorMessage));

                _logger.LogWarning("Validation failed for TodoTask '{Name}': {Errors}", request.Name, errorMessages);


                return Result.Failure(errorMessages);
            }

            _todoTaskRepository.Add(todoTask);
            var saveSucced = await _todoTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
           

            if (!saveSucced) { 
                _logger.LogError("Error saving TodoTask {Name}", request.Name);

                return Result.Failure("Error saving TodoTask");
            }

            _logger.LogInformation("TodoTask '{Name}' criada com sucesso.", request.Name);

            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exceção ao criar TodoTask '{Name}'", request.Name);

            return Result.Failure("Erro ao salvar TodoTask");
        }
    }
}
