namespace ToDoList.Application.Commands;

public record DeleteTodoTaskCommand(int Id):IRequest<Result>;

