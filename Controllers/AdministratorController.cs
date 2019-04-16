using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using RocketElevatorApi.Models;

namespace RocketElevatorApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase {
        private readonly RocketElevatorContext _context;

        public AdministratorController(RocketElevatorContext context) {
            _context = context;

        }

        // GET: api/Elevator
        [HttpGet]
        public IEnumerable<Administrator> GetAdministrators() {
            IQueryable<Administrator> Administrators =
            from le in _context.Administrators
            where le.email != null
            select le;

            return Administrators.ToList();
        }

        // GET: api/lead
   [HttpPost]
      public ActionResult<Administrator> PostAdministrator([FromBody]JObject email)
      {

          //get the value associate with the key of my Json object email
          var queryValidEmail = email.GetValue("email");

          var validEmail = queryValidEmail.ToString();

          //compare
          var administratorEmail = _context.Administrators.Where(e => e.email == validEmail);

          if (administratorEmail.Count() == 0)
          {
              return StatusCode(404);
          }
          else
          {
              return StatusCode(200);
              
          }


      }




        // [HttpPost("{email}")]
        // public async Task<ActionResult<string>> GetTodoItem(string email) {
        //     var todoItem = await _context.Administrators.FindAsync(email);

        //     if (todoItem == null) {
        //         return NotFound();
        //     }
        //         return email;
        // }

        //   [HttpGet("{email}")]
        // public async Task<ActionResult<Administrator>> GetEmailItem(string email) {
        //     var EmailItem = await _context.Administrators.FindAsync(email);

        //     if (EmailItem != null) {
        //         return  EmailItem;
        //     }

        //     return NotFound();
        // }

        // // [HttpPut("{id}")]
        // // public async Task<IActionResult> PutTodoItem(long id, Administrator item) {
        // //     _context.Entry(item).State = EntityState.Modified;

           

        // }


    }
}