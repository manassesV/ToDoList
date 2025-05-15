namespace ToDoList.Domain.Validations;

public class TodoTaskValidation: AbstractValidator<TodoTask>
{
    public TodoTaskValidation()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters");

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Description is required")
            .Length(2, 500).WithMessage("Description must be between 2 and 500 characters");

        RuleFor(c => c.DueDate)
            .NotEmpty().WithMessage("DueDate is required")
            .Must(BeValidDate).WithMessage("DueDate must be a valid date");
    }

    private bool BeValidDate(DateTime date)
    {
        return date > DateTime.Now;
    }
}
