using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using TodoAPI.DTO;
using TodoAPI.Entities;


namespace TodoAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        public AppDbContext db;


        public ToDoController(AppDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }


        [HttpPost]
        public async Task<IActionResult> ToDoAdd([FromBody] ToDoAddDto dto)
        {

            try
            {
                ToDo todo = new ToDo();
                todo.tittle = dto.tittle;
                todo.description = dto.description;
                db.Todos.Add(todo);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }


            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ToDoGetAll()
        {
            return Ok(db.Set<ToDo>().ToList());
        }
    }
}

