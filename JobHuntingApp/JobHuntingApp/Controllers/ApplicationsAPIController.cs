using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobHuntingApp.Data;
using JobHuntingApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobHuntingApp.Controllers
{
    [Produces("application/json")]
    [Route("api/ApplicationsAPI")]
    public class ApplicationsAPIController : Controller
    {
        private readonly JobHuntContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationsAPIController(JobHuntContext context, UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostApplication([FromBody] Application application)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return null;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_context.Applications.Any(x => x.JobID == application.JobID))
            {
                //Update instead of add.
                var newApplication = _context.Applications.SingleOrDefault(x => x.JobID == application.JobID);
                newApplication.ApplicationSubmitted = application.ApplicationSubmitted;
                newApplication.ApplicationMethod = application.ApplicationMethod;
            }
            else
            {
                application.UserID = user.Id;
                _context.Applications.Add(application);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.ApplicationID }, application);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }





    }
}
