using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieItemsController : ControllerBase
    {
        private readonly MovieContext _context;

        public MovieItemsController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/MovieItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieItem>>> GetMovieItems()
        {
            return await _context.MovieItems.ToListAsync();
        }

        // GET: api/MovieItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieItem>> GetMovieItem(long id)
        {
            var movieItem = await _context.MovieItems.FindAsync(id);

            if (movieItem == null)
            {
                return NotFound();
            }

            return movieItem;
        }

        // PUT: api/MovieItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieItem(long id, MovieItem movieItem)
        {
            if (id != movieItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieItemExists(id))
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

        // POST: api/MovieItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieItem>> PostMovieItem(MovieItem movieItem)
        {
            _context.MovieItems.Add(movieItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovieItem), new { id = movieItem.Id }, movieItem);
        }

        // DELETE: api/MovieItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieItem(long id)
        {
            var movieItem = await _context.MovieItems.FindAsync(id);
            if (movieItem == null)
            {
                return NotFound();
            }

            _context.MovieItems.Remove(movieItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieItemExists(long id)
        {
            return _context.MovieItems.Any(e => e.Id == id);
        }
    }
}
