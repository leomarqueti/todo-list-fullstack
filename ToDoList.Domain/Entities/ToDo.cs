using ToDoList.Communication.Enums;

namespace ToDoList.Api.Entities;

public class ToDo
{
    public Guid Id { get; set; } 
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty ;

    public string Priority {  get; set; } = string.Empty ;
    
    public DateTime DueDate { get; set; }

    public TypeStatus Status { get; set; }



    public ToDo(string name, string description, string priority,DateTime dueDate, TypeStatus status)
    {
        Id = Guid.NewGuid();
        Name = name ; 
        Description = description ;
        Priority = priority ;
        DueDate = dueDate ;
        Status = status ;


        if(name.Length > 100)
        {
            throw new Exception("O nome não pode ter mais que 100 caracteres");
        }

        if (description.Length > 100) 
        {
            throw new Exception("A descrição não pode ter mais que 100 caracteres");
        }
    }
}
