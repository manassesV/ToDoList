
namespace ToDoList.Infrastructure;

public class ToDoListDbContext:DbContext, IUnitOfWork
{

    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options): base(options){}
    
    public DbSet<TodoTask> TodoTasks { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoListDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

}
