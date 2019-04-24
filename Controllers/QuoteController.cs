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
    public class QuoteController : ControllerBase
    {
        private readonly RocketElevatorContext _context;

        public QuoteController(RocketElevatorContext context)
        {
            _context = context;
        }

        // GET: api/Quote
        [HttpGet("quote")]
        public IEnumerable<Quote> GetQuotes()
        {
            IQueryable<Quote> Quotes =
            from le in _context.Quotes
            select le;

            return Quotes.ToList();
        }
    }
}