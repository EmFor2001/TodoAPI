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
                todo.title = dto.title;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> ToDoGetById(Guid id)
        {
            return Ok(db.Set<ToDo>().Find(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ToDoUpdate(Guid id, [FromBody] ToDoUpdateDto dto)
        {
            try
            {
                ToDo todo = db.Set<ToDo>().Find(id);
                todo.title = dto.title;
                todo.description = dto.description;
                db.Entry(todo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> TodoDelete(Guid id)
        {
            try
            {
                ToDo todo = db.Set<ToDo>().Find(id);
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(400);
            }
            return Ok();
        }   
    }
}

