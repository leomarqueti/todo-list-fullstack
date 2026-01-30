using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Communication.Request;
public class RequestRegisterToDoListJson
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public DateTime? DueDate { get; set; }

    public string Status { get; set; } = string.Empty;



    
}
