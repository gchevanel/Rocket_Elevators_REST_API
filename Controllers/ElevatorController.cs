using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public ElevatorController(RocketElevatorContext context)
        {
            _context = context;

            // if (_context.Elevators.Count() == 0) {
            //     // Create a new TodoItem if collection is empty,
            //     // which means you can't delete all TodoItems.
            //     _context.Elevators.Add(new Elevator { Name = "Item1" });
            //     _context.SaveChanges();
            // }
        }

        // GET: api/Elevator
        [HttpGet]
        public IEnumerable<Elevator> GetElevators()
        {
            IQueryable<Elevator> Elevators =
           from le in _context.Elevators
           where le.status == "Intervention" || le.status == "Inactive"
           select le;

            return Elevators.ToList();
        }


        //  public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems() {
        //      return await _context.TodoItems.ToListAsync();
        //  }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetTodoItem(long id)
        {
            var todoItem = await _context.Elevators.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpGet("all")]
        public IEnumerable<Elevator> GetAllElevators()
        {
            IQueryable<Elevator> Elevators =
           from le in _context.Elevators
           where le.status == "Intervention" || le.status == "Inactive" || le.status == "Active"
           select le;

            return Elevators.ToList();
        }
        // // POST: api/Todo
        // [HttpPost]
        // public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item) {
        //     _context.TodoItems.Add(item);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        // }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Elevator item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            if (item.status == "Intervention" || item.status == "Active" || item.status == "Inactive")
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Content("Elevator: " + item.id + ", status as been change to: " + item.status);
            }

            return Content("You need to insert a valid status : Intervention, Inactive, Active, Thank you !  ");

        }

        // // DELETE: api/Todo/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteTodoItem(long id) {
        //     var todoItem = await _context.TodoItems.FindAsync(id);

        //     if (todoItem == null) {
        //         return NotFound();
        //     }

        //     _context.TodoItems.Remove(todoItem);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}