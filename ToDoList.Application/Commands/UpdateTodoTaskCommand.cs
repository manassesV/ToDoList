namespace ToDoList.Application.Commands;

public record UpdateTodoTaskCommand(
    string Name,
    string Description,
    DateTime DueDate,
    Status Status
):IRequest<Result>;

