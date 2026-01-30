using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Communication.Response;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.UseCase.GetAll;
public class GetAllUseCase
{
    private readonly IToDoRepository _repository;


    public GetAllUseCase(IToDoRepository repository)
    {
        _repository = repository;
    }

    public ResponseGetAllToDoJson Execute()
    {

        //busca dados brutos 
        var result = _repository.GetAll();

        var response = new ResponseGetAllToDoJson();


        foreach (var entity in result) 
        {
            response.ToDoList.Add(new ResponseShortGetToDoJson
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            });
        }

        return response;
    }
}
