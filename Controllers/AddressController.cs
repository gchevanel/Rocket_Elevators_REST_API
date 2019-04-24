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
    public class AddressController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public AddressController(RocketElevatorContext context)
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
        public IEnumerable<Address> GetAddresses()
        {
            IQueryable<Address> Addresses =
           (from le in _context.Addresses
            where le.entity == "Building"
            select le).GroupBy(c => c.city).Select(a => a.FirstOrDefault());
            var data = Addresses.GroupBy(c => c.city).Select(a => a.FirstOrDefault());

            return Addresses.ToList();
        }


        //  public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems() {
        //      return await _context.TodoItems.ToListAsync();
        //  }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetTodoItem(long id)
        {
            var todoItem = await _context.Addresses.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        [HttpGet("all")]
        public IEnumerable<Address> GetElev()
        {
            return _context.Addresses;
        }
        // // POST: api/Todo
        // [HttpPost]
        // public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item) {
        //     _context.TodoItems.Add(item);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        // }

        // PUT: api/Todo/5


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