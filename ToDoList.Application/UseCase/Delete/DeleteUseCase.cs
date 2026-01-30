using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCase.Delete;
public class DeleteUseCase
{
    private readonly IToDoRepository _repository;

    public DeleteUseCase(IToDoRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id)
    {
        var toDo = _repository.GetById(id);

        if (toDo is not null)
        {
            _repository.Delete(toDo);
        }
    }
}
