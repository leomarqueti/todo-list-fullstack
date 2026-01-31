using System.Runtime.InteropServices;
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

        if (string.IsNullOrWhiteSpace(request.Name)) 
        {
            throw new ArgumentException("O nome da tarefa não pode ser vazio");
        }

        if (request.Name.Length > 100)
        {
            throw new ArgumentException("O nome não pode ter mais do que 100 caracteres");
        }

        if (request.DueDate < DateTime.Now)
        {
            throw new ArgumentException("A data não pode ser menor que a data atual");
        }

        if (int.Parse(request.Status) > 2)
        {
            throw new ArgumentException("Status fora do valor permitido");
        }

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
