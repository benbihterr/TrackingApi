using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingApi.Data;
using TrackingApi.Models;

namespace TrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _context;

        public IssueController(IssueDbContext context) => _context = context;
        
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get() 
            => await _context.Issues.ToListAsync();
      
        [HttpGet("id")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }


    }
}
