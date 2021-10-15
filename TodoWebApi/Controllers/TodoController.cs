using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoWebApi.Data;
using TodoWebApi.Services.Interfaces;
using TodoWebApi.ViewModels;

namespace TodoWebApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {
        private readonly ITodosService _todosService;

        public TodoController(ITodosService todosService)
        {
            _todosService = todosService;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAsync()
        {
            var todos = await _todosService.GetTodosAsync(); ;
            return Ok(todos);
        }
        
        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute ]int id)
        {
            var todo = await _todosService.GetTodoByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }
            
            return Ok(todo);
        }

        [HttpPost("todos")]
        public async Task<IActionResult> PostAsync([FromBody] CreateTodoViewModel createTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var todo = await _todosService.CreateTodoAsync(createTodo);
                return Created($"v1/todos/{todo.Id}", todo);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("todos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] UpdateTodoViewModel updateTodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var todo = _todosService.GetTodoByIdAsync(id).Result;

            if (todo == null)
            {
                return NotFound();
            }

            try
            {
                await _todosService.UpdateTodoAsync(updateTodo, id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpDelete("todos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            try
            {
                await _todosService.DeleteTodoAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
