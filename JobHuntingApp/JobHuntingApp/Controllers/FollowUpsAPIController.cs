using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobHuntingApp.Data;
using JobHuntingApp.Models;

namespace JobHuntingApp.Controllers
{    
    [Produces("application/json")]
    [Route("api/FollowUpsAPI")]
    public class FollowUpsAPIController : Controller
    {
        private readonly JobHuntContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FollowUpsAPIController(JobHuntContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/FollowUpsAPI
        [HttpGet]
        public IEnumerable<FollowUp> GetFollowUps()
        {
            return _context.FollowUps;
        }

        // GET: api/FollowUpsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFollowUp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var followUp = await _context.FollowUps.SingleOrDefaultAsync(m => m.FollowUpID == id);

            if (followUp == null)
            {
                return NotFound();
            }

            return Ok(followUp);
        }

        // PUT: api/FollowUpsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowUp([FromRoute] int id, [FromBody] FollowUp followUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != followUp.FollowUpID)
            {
                return BadRequest();
            }

            _context.Entry(followUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowUpExists(id))
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

        // POST: api/FollowUpsAPI
        [HttpPost]
        public async Task<IActionResult> PostFollowUp([FromBody] FollowUp followUp)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Check to see if this is a resubmission.
            if(followUp.FollowUpID != 0)
            {
                //This is a resubmission
                var tempFollowUp = _context.FollowUps.SingleOrDefault(x => x.FollowUpID == followUp.FollowUpID && x.UserID == user.Id);
                if(tempFollowUp != null)
                {
                    tempFollowUp.FollowUpMethod = followUp.FollowUpMethod;
                    tempFollowUp.FollowUpOccured = followUp.FollowUpOccured;
                    tempFollowUp.FollowUpNotes = followUp.FollowUpNotes;
                    //Update the old record
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Something went wrong.

                }
            }
            else
            {
                //Create a new followup record.
                followUp.UserID = user.Id;
                _context.FollowUps.Add(followUp);
                await _context.SaveChangesAsync();
            }
            
            return CreatedAtAction("GetFollowUp", new { id = followUp.FollowUpID }, followUp);
        }

        // DELETE: api/FollowUpsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFollowUp([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var followUp = await _context.FollowUps.SingleOrDefaultAsync(m => m.FollowUpID == id);
            if (followUp == null)
            {
                return NotFound();
            }

            _context.FollowUps.Remove(followUp);
            await _context.SaveChangesAsync();

            return Ok(followUp);
        }

        private bool FollowUpExists(int id)
        {
            return _context.FollowUps.Any(e => e.FollowUpID == id);
        }


        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }


    }
}