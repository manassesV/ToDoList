namespace ToDoList.Application.Commands;

public class DeleteTodoTaskCommandHandler : IRequestHandler<DeleteTodoTaskCommand, Result>
{
    private readonly ITodoTaskRepository _todoTaskRepository;
    private readonly ILogger<DeleteTodoTaskCommandHandler> _logger;

    public DeleteTodoTaskCommandHandler(ITodoTaskRepository todoTaskRepository,
        ILogger<DeleteTodoTaskCommandHandler> logger)
    {
        _todoTaskRepository = todoTaskRepository;
        _logger = logger;
    }
    public async Task<Result> Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todoTask = await _todoTaskRepository.FindByIdAsync(request.Id);

            if (todoTask is null)
            {
                _logger.LogWarning("TodoTask com ID {Id} não encontrada", request.Id);
                return Result.Failure("TodoTask não encontrada");
            }

            _todoTaskRepository.Delete(todoTask);

            var removed = await _todoTaskRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (!removed)
            {
                _logger.LogError("Erro ao salvar a TodoTask '{Name}'", todoTask.Name);
                return Result.Failure("Erro ao salvar a TodoTask");
            }

            _logger.LogInformation("TodoTask '{Name}' atualizada com sucesso.", todoTask.Name);
            return Result.Success(); // ou Success(todoTask)
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exceção ao atualizar a TodoTask");
            return Result.Failure("Erro ao atualizar a TodoTask");
        }
    }
}
