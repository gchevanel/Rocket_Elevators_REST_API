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
    public class InterventionController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public InterventionController(RocketElevatorContext context) {
            _context = context;

        }

        // GET: api/Elevator
        [HttpGet]
        public IEnumerable<Intervention> GetInterventions() {
            IQueryable<Intervention> Interventions =
            from le in _context.Interventions
            where le.InterventionFinishedDate == null && le.Status == "pending"
            select le;

            return Interventions.ToList();
        }

        // GET: api/lead
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetTodoItem(long id) {
            var todoItem = await _context.Interventions.FindAsync(id);

            if (todoItem == null) {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, Intervention item) {
            _context.Entry(item).State = EntityState.Modified;

            if (id != item.id) {
                return BadRequest();
            }
            if (item.Status == "InProgress"){
            item.InterventionStartingDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
            }
            if (item.Status == "Completed"){
            item.InterventionFinishedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
            }
            if (item.Status == "Pending"){
            item.InterventionStartingDate = null;
            item.InterventionFinishedDate = null;

            await _context.SaveChangesAsync();
            return NoContent();
            }
            else
                {
                return BadRequest();
                }

        }


    }
}