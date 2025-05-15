namespace ToDoList.Application.Commands;

public record CreateTodoTaskCommand(
    string Name,
    string Description,
    DateTime DueDate,
    Status Status
):IRequest<Result>;

public enum Status
{
    Pending = 1,
    InProgress = 2,
    Completed = 3,
    Cancelled = 4
}