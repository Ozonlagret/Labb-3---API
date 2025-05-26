using Labb_3___API.Data;
using Labb_3___API.Models;
using Labb_3___API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb_3___API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class InterestController : ControllerBase
    {
        private readonly AppDbContext? _context;

        public InterestController(AppDbContext? context) { _context = context; }

        [HttpGet("{personId}/Getinterests")]
        public async Task<ActionResult<IEnumerable<InterestDto>>> GetInterestsByPerson(int personId)
        {
            var personExists = await _context.Persons.AnyAsync(p => p.Id == personId);
            if (!personExists)
                return NotFound($"Person could not be found");

            var interests = await _context.PersonInterests
                .Where(pi => pi.PersonId == personId)
                .Select(pi => new InterestDto
                {
                    Id = pi.Interest.Id,
                    Title = pi.Interest.Title,
                    Description = pi.Interest.Description
                })
                .ToListAsync();

            return Ok(interests);
        }


        [HttpPost("{personId}/addInterest")]
        public async Task<IActionResult> AddInterestToPerson(int personId, AddInterestToPersonDto dto)
        {
            var personExists = await _context.Persons.AnyAsync(p => p.Id == personId);
            if (!personExists)
                return NotFound($"Person could not be found");

            var personInterestExists = await _context.PersonInterests
                .Include(pi => pi.Interest)
                .FirstOrDefaultAsync(pi =>
                    pi.PersonId == personId &&
                    pi.Interest.Title == dto.Title &&
                    pi.Interest.Description == dto.Description);

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Title) || dto.Title.Contains("string"))
                errors.Add("Title can't be empty or a placeholder");

            if (string.IsNullOrWhiteSpace(dto.Description) || dto.Description.Contains("string"))
                errors.Add("Description can't be empty or a placeholder");

            if (personInterestExists != null)
                errors.Add("Person already has this interest");

            if (errors.Any())
                return BadRequest(new { Errors = errors });

            var interestExists = await _context.Interests
                .FirstOrDefaultAsync(i => i.Title == dto.Title && i.Description == dto.Description);

            Interest interest;

            if (interestExists != null)
            {
                interest = interestExists;
            }
            else
            {
                interest = new Interest
                {
                    Title = dto.Title,
                    Description = dto.Description
                };

                _context.Interests.Add(interest);
                await _context.SaveChangesAsync();
            }

            var personInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interest.Id
            };
            _context.PersonInterests.Add(personInterest);
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
