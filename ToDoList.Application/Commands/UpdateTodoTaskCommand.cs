namespace ToDoList.Application.Commands;

public record UpdateTodoTaskCommand(
    int Id,
    string Name,
    string Description,
    DateTime DueDate,
    Status Status
):IRequest<Result>;

