using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.UseCase.Delete;
using ToDoList.Application.UseCase.GetAll;
using ToDoList.Application.UseCase.GetById;
using ToDoList.Application.UseCase.Register;
using ToDoList.Application.UseCase.Update;
using ToDoList.Communication.Request;
using ToDoList.Communication.Response;
using ToDoList.Domain.Repositories;

namespace ToDoList.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ToDoListController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterToDoJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

    public IActionResult Register([FromBody] RequestRegisterToDoListJson request, [FromServices] IToDoRepository repository)
    {
        
        try
        {
            var toDo = new RegisterUseCase(repository).Execute(request);

            return Created(string.Empty, toDo);
        } catch (ArgumentException ex)
        {
            return BadRequest(new {message = ex.Message});
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {message = ex.Message});
        }
        
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetAllToDoJson),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]  

    public IActionResult GetAll([FromServices] IToDoRepository repository)
    {
        
        var useCase = new GetAllUseCase(repository);

        var response = useCase.Execute();

        if (response.ToDoList.Any())
        {
            return Ok(response);
        }

        return NoContent();      
    }


    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseGetByIdToDoJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute]Guid id, [FromServices] IToDoRepository repository) 
    {

        

        var useCase = new GetByIdUseCaSE(repository);

        var response = useCase.Execute(id);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestRegisterToDoListJson request, [FromServices] IToDoRepository repository)
    {

        var useCase = new UpdateUseCase(repository);

        var check = repository.GetById(id);

        if (check == null)
        {
            return NotFound();
        }

        useCase.Execute(id,request);

        return NoContent();

    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult Delete([FromRoute] Guid id, [FromServices] IToDoRepository repository) 
    {

        try
        {
            var useCase = new DeleteUseCase(repository);

            useCase.Execute(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message});
        }
        

        
            
        

        
    }


}
