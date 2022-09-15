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
    public class BloggerChannelsController : ControllerBase
    {
        private readonly VideoAPIContext _context;

        public BloggerChannelsController(VideoAPIContext context)
        {
            _context = context;
        }

        // GET: api/BloggerChannels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloggerChannel>>> GetBloggerChannels()
        {
          if (_context.BloggerChannels == null)
          {
              return NotFound();
          }
            return await _context.BloggerChannels.ToListAsync();
        }

        // GET: api/BloggerChannels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloggerChannel>> GetBloggerChannel(int id)
        {
          if (_context.BloggerChannels == null)
          {
              return NotFound();
          }
            var bloggerChannel = await _context.BloggerChannels.FindAsync(id);

            if (bloggerChannel == null)
            {
                return NotFound();
            }

            return bloggerChannel;
        }

        // PUT: api/BloggerChannels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloggerChannel(int id, BloggerChannel bloggerChannel)
        {
            if (id != bloggerChannel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bloggerChannel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloggerChannelExists(id))
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

        // POST: api/BloggerChannels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BloggerChannel>> PostBloggerChannel(BloggerChannel bloggerChannel)
        {
          if (_context.BloggerChannels == null)
          {
              return Problem("Entity set 'VideoAPIContext.BloggerChannels'  is null.");
          }
            _context.BloggerChannels.Add(bloggerChannel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloggerChannel", new { id = bloggerChannel.Id }, bloggerChannel);
        }

        // DELETE: api/BloggerChannels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloggerChannel(int id)
        {
            if (_context.BloggerChannels == null)
            {
                return NotFound();
            }
            var bloggerChannel = await _context.BloggerChannels.FindAsync(id);
            if (bloggerChannel == null)
            {
                return NotFound();
            }

            _context.BloggerChannels.Remove(bloggerChannel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloggerChannelExists(int id)
        {
            return (_context.BloggerChannels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
