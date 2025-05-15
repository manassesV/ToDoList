namespace ToDoList.Domain.AggregatesModel.TodoTaskAggregate;

public interface ITodoTaskRepository: IRepository<TodoTask>
{
    TodoTask Add(TodoTask todoTask);
    TodoTask Update(TodoTask todoTask);
    TodoTask Delete(TodoTask todoTask);
    Task<IEnumerable<TodoTask>> FindAllAsync();
    Task<TodoTask> FindByIdAsync(int id);
}
