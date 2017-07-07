using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobHuntingApp.Data;
using JobHuntingApp.Models;

namespace JobHuntingApp.Controllers
{
    [Produces("application/json")]
    [Route("api/CoverLettersAPI")]
    public class CoverLettersAPIController : Controller
    {
        private readonly JobHuntContext _context;

        public CoverLettersAPIController(JobHuntContext context)
        {
            _context = context;
        }

        // GET: api/CoverLettersAPI
        [HttpGet]
        public IEnumerable<CoverLetter> GetCoverLetters()
        {
            return _context.CoverLetters;
        }

        // GET: api/CoverLettersAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoverLetter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id);

            if (coverLetter == null)
            {
                return NotFound();
            }

            return Ok(coverLetter);
        }

        // PUT: api/CoverLettersAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoverLetter([FromRoute] int id, [FromBody] CoverLetter coverLetter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coverLetter.CoverLetterID)
            {
                return BadRequest();
            }

            _context.Entry(coverLetter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoverLetterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CoverLettersAPI
        [HttpPost]
        public async Task<IActionResult> PostCoverLetter([FromBody] CoverLetter coverLetter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoverLetters.Add(coverLetter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoverLetter", new { id = coverLetter.CoverLetterID }, coverLetter);
        }

        // DELETE: api/CoverLettersAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoverLetter([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coverLetter = await _context.CoverLetters.SingleOrDefaultAsync(m => m.CoverLetterID == id);
            if (coverLetter == null)
            {
                return NotFound();
            }

            _context.CoverLetters.Remove(coverLetter);
            await _context.SaveChangesAsync();

            return Ok(coverLetter);
        }

        private bool CoverLetterExists(int id)
        {
            return _context.CoverLetters.Any(e => e.CoverLetterID == id);
        }
    }
}