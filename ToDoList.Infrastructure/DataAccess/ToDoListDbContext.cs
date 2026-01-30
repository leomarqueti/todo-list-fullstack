using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Api.Entities;

namespace ToDoList.Infrastructure.DataAccess;
public  class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ToDo> ToDos { get; set; } 
}
