namespace ToDoList.Application.Queries;

public interface ITodoTaskQueries
{
    Task<Result<IEnumerable<TodoTaskViewModel>>> FindAllAsync(CancellationToken cancellationToken);
    Task<Result<TodoTaskViewModel>> FindByIdAsync(int id, CancellationToken cancellationToken);
}
