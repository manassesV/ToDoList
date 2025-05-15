namespace ToDoList.Application.Queries;

public class TodoTaskQueries(ToDoListDbContext context,
     ILogger<TodoTaskQueries> logger) : ITodoTaskQueries
{
    public async Task<Result<IEnumerable<TodoTaskViewModel>>> FindAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var todoTasks = await context.TodoTasks
                .AsNoTracking()
                .Select(x => new TodoTaskViewModel(x.Id, x.Name, x.Description, x.DueDate, x.Status ))
                .ToListAsync(cancellationToken);

            return Result<IEnumerable<TodoTaskViewModel>>.Success(todoTasks);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar todas as tarefas.");
            return Result<IEnumerable<TodoTaskViewModel>>.Failure("Erro ao buscar todas as tarefas.");
        }
    }

    public async Task<Result<TodoTaskViewModel>> FindByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var todoTask = await context.TodoTasks
                .Where(x => x.Id == id)
                .Select(x => new TodoTaskViewModel(x.Id, x.Name, x.Description, x.DueDate, x.Status))
                .FirstOrDefaultAsync(cancellationToken);

            if (todoTask is null)
                return Result<TodoTaskViewModel>.Failure("Tarefa não encontrada.");

            return Result<TodoTaskViewModel>.Success(todoTask);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar tarefa por ID.");
            return Result<TodoTaskViewModel>.Failure("Erro ao buscar tarefa por ID.");
        }
    }
}
