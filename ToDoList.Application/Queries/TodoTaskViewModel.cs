using Status = ToDoList.Domain.AggregatesModel.TaskAggregate.Status;

namespace ToDoList.Application.Queries;

public record TodoTaskViewModel(
    int Id,
    string Name,
    string Description,
    DateTime DueDate,
    Status Status);
