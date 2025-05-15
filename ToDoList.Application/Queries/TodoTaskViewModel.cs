namespace ToDoList.Application.Queries;

public record TodoTaskViewModel(
    int Id,
    string Name,
    string Description,
    DateTime DueDate,
    bool Status);
