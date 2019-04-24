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

namespace RocketElevatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public LeadController(RocketElevatorContext context)
        {
            _context = context;
        }

        // GET: api/lead

        [HttpGet]
        public IEnumerable<Lead> GetLeadss()
        {
            IQueryable<Lead> Leads =
            from le in _context.Leads

            select le;

            return Leads.ToList();
        }
        [HttpGet("recent")]
        public IEnumerable<Lead> GetLeads()
        {
            IQueryable<Lead> Leads =
            from le in _context.Leads
            where le.customer_id == null && le.created_at >= DateTime.Now.AddDays(-30)
            select le;

            return Leads.ToList();
        }
    }
}