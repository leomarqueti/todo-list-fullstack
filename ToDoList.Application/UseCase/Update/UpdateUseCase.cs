using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Communication.Enums;
using ToDoList.Communication.Request;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCase.Update;
public class UpdateUseCase
{
    private readonly IToDoRepository _repository;

    public UpdateUseCase(IToDoRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id, RequestRegisterToDoListJson request) 
    { 
        //Busca o item existente no banco
        var toDo = _repository.GetById(id);

        if (toDo is null)
        {
            return;
        }

        toDo.Name = request.Name;
        toDo.Description = request.Description;
        toDo.Priority = request.Priority;

        toDo.DueDate = request.DueDate ?? DateTime.Now;

        toDo.Status = Enum.Parse<TypeStatus>(request.Status);

        _repository.Update(toDo);

    }
}
