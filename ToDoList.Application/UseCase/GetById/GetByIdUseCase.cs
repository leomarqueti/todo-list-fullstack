using ToDoList.Communication.Response;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCase.GetById;

public class GetByIdUseCaSE
{
    private readonly IToDoRepository _repository;

    public GetByIdUseCaSE(IToDoRepository repository)
    {
        _repository = repository;
    }

    public ResponseGetByIdToDoJson Execute(Guid id)
    {
        var entity = _repository.GetById(id);

        if (entity is null) 
        {
            return null;
        }

        return new ResponseGetByIdToDoJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Priority = entity.Priority,
            DueDate = entity.DueDate,
            Status = entity.Status.ToString()
        };

    }
}
