using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Communication.Response;
public class ResponseGetAllToDoJson
{
    public List<ResponseShortGetToDoJson> ToDoList { get; set; } = new List<ResponseShortGetToDoJson>();
}
