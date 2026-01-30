using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Api.Entities;

namespace ToDoList.Domain.Repositories;
public interface IToDoRepository
{
    void Add(ToDo toDo);

    //Rertona uma lista de entidades
    List<ToDo> GetAll();

    //Busca Id especifico

    ToDo? GetById(Guid id);

    void Update(ToDo toDo);

    void Delete(ToDo toDo);
}
