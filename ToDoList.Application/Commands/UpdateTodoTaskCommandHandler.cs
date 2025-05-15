namespace ToDoList.Application.Commands;

public class UpdateTodoTaskCommandHandler : IRequestHandler<UpdateTodoTaskCommand, Result>
{
    private readonly ITodoTaskRepository _todoTaskRepository;
    private readonly ILogger<CreateTodoTaskCommandHandler> _logger;

    public UpdateTodoTaskCommandHandler(ITodoTaskRepository todoTaskRepository,
        ILogger<CreateTodoTaskCommandHandler> logger)
    {
        _todoTaskRepository = todoTaskRepository;
        _logger = logger;
    }
    public async Task<Result> Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todoTask = await _todoTaskRepository.FindByIdAsync(request.Id);

            if (todoTask is null)
            {
                _logger.LogWarning("TodoTask com ID {Id} não encontrada", request.Id);
                return Result.Failure("TodoTask não encontrada");
            }

            todoTask.Update(request.Name, request.Description, request.DueDate, request.Status);
            _todoTaskRepository.Update(todoTask);

            var updatted = await _todoTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (!updatted)
            {
                _logger.LogError("Erro ao salvar a TodoTask '{Name}'", request.Name);
                return Result.Failure("Erro ao salvar a TodoTask");
            }

            _logger.LogInformation("TodoTask '{Name}' atualizada com sucesso.", request.Name);
            return Result.Success(); // ou Success(todoTask)
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exceção ao atualizar a TodoTask '{Name}'", request.Name);
            return Result.Failure("Erro ao atualizar a TodoTask");
        }
    }
}
