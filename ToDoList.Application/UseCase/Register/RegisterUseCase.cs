using ToDoList.Api.Entities;
using ToDoList.Communication.Enums;
using ToDoList.Communication.Request;
using ToDoList.Communication.Response;
using ToDoList.Domain.Repositories;


namespace ToDoList.Application.UseCase.Register;
public class RegisterUseCase
{
    private readonly IToDoRepository _repository;

    public RegisterUseCase(IToDoRepository repository)
    {
        _repository = repository;
    }

    public ResponseRegisterToDoJson Execute(RequestRegisterToDoListJson request)
    {

        var statusEnum = Enum.Parse<TypeStatus>(request.Status);
        var dueToUse = request.DueDate ?? DateTime.MinValue;

        var toDo = new ToDo
        (
            request.Name,
            request.Description,
            request.Priority,
            dueToUse,
            statusEnum
        );

        _repository.Add( toDo );

        return new ResponseRegisterToDoJson
        {
            Id = toDo.Id,
            Name = toDo.Name,
        };
    }
}
