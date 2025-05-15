namespace ToDoList.Infrastructure.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly ToDoListDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public TodoTaskRepository(ToDoListDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public TodoTask Add(TodoTask todoTask)
    {
        return _context.TodoTasks.Add(todoTask).Entity;
    }

    public async Task<IEnumerable<TodoTask>> FindAllAsync()
    {
        return await _context.TodoTasks
             .AsNoTracking()
             .ToListAsync();       
    }

    public async Task<TodoTask> FindByIdAsync(int id)
    {
        return await _context.TodoTasks
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public TodoTask Update(TodoTask todoTask)
    {
        return _context.TodoTasks.Update(todoTask).Entity;
    }

    public TodoTask Delete(TodoTask todoTask)
    {
        return _context.TodoTasks.Remove(todoTask).Entity;

    }
}
