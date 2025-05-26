using Labb_3___API.Data;
using Labb_3___API.Models;
using Labb_3___API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Labb_3___API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LinkController : ControllerBase
    {
        private readonly AppDbContext? _context;

        public LinkController(AppDbContext? context) { _context = context; }

        [HttpGet("{personId}/getLinksByPerson")]
        public async Task<ActionResult<IEnumerable<LinkDto>>> GetLinksByPerson(int personId)
        {
            var personExists = await _context.Persons.AnyAsync(p => p.Id == personId);
            if (!personExists)
                return NotFound($"Person could not be found");

            var links = await _context.Links
                .Where(l => l.PersonId == personId)
                .Select(l => new LinkDto
                {
                    Id = l.Id,
                    Url = l.Url,
                    InterestId = l.InterestId,
                    PersonId = l.PersonId
                })
                .ToListAsync();

            return Ok(links);
        }


        [HttpPost("{personId}/linkToPersonInterest")]
        public async Task<IActionResult> AddLinkToPersonInterest(int personId, CreateLinkDto createLink)
        {
            var link = new Link
            {
                Url = createLink.Url,
                PersonId = personId,
                InterestId = createLink.InterestId
            };

            _context.Links.Add(link);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
