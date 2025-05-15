namespace ToDoList.Infrastructure.EntityConfigurations;

public class ToDoTaskEntityConfigurations:IEntityTypeConfiguration<TodoTask>
{
    public void Configure(EntityTypeBuilder<TodoTask> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
        builder.Property(t => t.DueDate).IsRequired();
        builder.Property(t => t.Status).IsRequired();
        builder.Ignore(t => t.ValidationResult);
    }
}
