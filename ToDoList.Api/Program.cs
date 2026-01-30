using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure.DataAccess;
using ToDoList.Infrastructure.DataAccess;
using ToDoList.Infrastructure.Repositories; 
using ToDoList.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<ToDoListDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
