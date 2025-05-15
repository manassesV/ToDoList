namespace ToDoList.Application.Commands;

public record CreateTodoTaskCommand(
    string Name,
    string Description,
    DateTime DueDate,
    bool Status
):IRequest<Result>;

