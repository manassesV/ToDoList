namespace ToDoList.Application.Commands;

public record UpdateTodoTaskCommand(
    int Id,
    string Name,
    string Description,
    DateTime DueDate,
    bool Status
):IRequest<Result>;

