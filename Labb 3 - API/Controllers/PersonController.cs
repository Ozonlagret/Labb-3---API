using Labb_3___API.Data;
using Labb_3___API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context) { _context = context; }

        [HttpGet (Name = "GetAllPeople")]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
        {
            var persons = await _context.Persons
                .Select(p => new PersonDto { Id = p.Id, Name = p.Name, Phone = p.Phone })
                .ToListAsync();

            return Ok(persons);
        }


    }
}
