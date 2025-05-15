namespace ToDoList.Domain.AggregatesModel.TaskAggregate;

public class TodoTask: Entity, IAggregateRoot
{
    public TodoTask(string name, string description, DateTime dueDate)
    {
        Name = name;
        Description = description;
        DueDate = dueDate;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime DueDate { get; private set; }
    public Status Status { get; private set; } = Status.Pending;
    public void Update(string name, string description, DateTime dueDate)
    {   
        Name = name;
        Description = description;
        DueDate = dueDate;
    }

    public void UpdateStatus(Status status)
    {
        Status = status;
    }

    public bool isValid()
    {
        ValidationResult = new TodoTaskValidation().Validate(this);

        return ValidationResult.IsValid;
    }
}
