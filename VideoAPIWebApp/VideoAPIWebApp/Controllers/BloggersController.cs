using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoAPIWebApp.Models;

namespace VideoAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggersController : ControllerBase
    {
        private readonly VideoAPIContext _context;

        public BloggersController(VideoAPIContext context)
        {
            _context = context;
        }

        // GET: api/Bloggers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blogger>>> GetBloggers()
        {
          if (_context.Bloggers == null)
          {
              return NotFound();
          }
            return await _context.Bloggers.ToListAsync();
        }

        // GET: api/Bloggers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blogger>> GetBlogger(int id)
        {
          if (_context.Bloggers == null)
          {
              return NotFound();
          }
            var blogger = await _context.Bloggers.FindAsync(id);

            if (blogger == null)
            {
                return NotFound();
            }

            return blogger;
        }

        // PUT: api/Bloggers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogger(int id, Blogger blogger)
        {
            if (id != blogger.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloggerExists(id))
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

        // POST: api/Bloggers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blogger>> PostBlogger(Blogger blogger)
        {
          if (_context.Bloggers == null)
          {
              return Problem("Entity set 'VideoAPIContext.Bloggers'  is null.");
          }
            _context.Bloggers.Add(blogger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogger", new { id = blogger.Id }, blogger);
        }

        // DELETE: api/Bloggers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogger(int id)
        {
            if (_context.Bloggers == null)
            {
                return NotFound();
            }
            var blogger = await _context.Bloggers.FindAsync(id);
            if (blogger == null)
            {
                return NotFound();
            }

            _context.Bloggers.Remove(blogger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloggerExists(int id)
        {
            return (_context.Bloggers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
