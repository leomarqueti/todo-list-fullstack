using ToDoList.Api.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.DataAccess;

namespace ToDoList.Infrastructure.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly ToDoListDbContext _dbContext;

    
    public ToDoRepository(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(ToDo toDo)
    {
        _dbContext.ToDos.Add(toDo);
        _dbContext.SaveChanges(); 
    }

    public List<ToDo> GetAll()
    {
        return _dbContext.ToDos.ToList();
    }

    public ToDo? GetById(Guid id)
    {
        return _dbContext.ToDos.FirstOrDefault(x => x.Id == id);
    }

    public void Update(ToDo toDo)
    {
        _dbContext.ToDos.Update(toDo);
        _dbContext.SaveChanges();
    }

    public void Delete(ToDo toDo) 
    {
        _dbContext?.ToDos.Remove(toDo);

        _dbContext.SaveChanges();
    }
}