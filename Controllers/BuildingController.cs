using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySql.Data.MySqlClient;

using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public BuildingController(RocketElevatorContext context) {
            _context = context;

            // if (_context.Elevators.Count() == 0) {
            //     // Create a new TodoItem if collection is empty,
            //     // which means you can't delete all TodoItems.
            //     _context.Elevators.Add(new Elevator { Name = "Item1" });
            //     _context.SaveChanges();
            // }
        }

        // GET: api/building
        [HttpGet]
        public IEnumerable<Building> GetBuildings() {
            return _context.Buildings;
        }

        // GET: api/building/5
        [HttpGet("intervention")]
        public IEnumerable<Building> GetBuildingsIntervention() {
            //Starting a query in lambda 
            //This query look for each Battery, Columns and Elevators that have a status set to Intervention 
            //and return the corresponding Building informations.
            IQueryable<Building> Building =
                from bu in _context.Buildings
                join ba in _context.Batteries on bu.id equals ba.building_id
                join co in _context.Columns on ba.id equals co.battery_id
                join el in _context.Elevators on co.id equals el.column_id
            where ba.status == "Intervention" || co.status == "Intervention" || el.status == "Intervention"
            select bu;

            //Return the IQueryable Building lambda as a list. 
            return Building.ToList();
        }

        // // POST: api/Todo
        // [HttpPost]
        // public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item) {
        //     _context.TodoItems.Add(item);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        // }

        // // PUT: api/Todo/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutTodoItem(long id, TodoItem item) {
        //     if (id != item.Id) {
        //         return BadRequest();
        //     }

        //     _context.Entry(item).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

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