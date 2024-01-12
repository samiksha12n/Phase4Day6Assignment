using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phase4Day6Assignment.Data;
using Phase4Day6Assignment.Models;

namespace Phase4Day6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly Phase4Day6AssignmentDbContext _context;
        List<Movies> movie = new List<Movies>()
{
    new Movies(){ID=1,Title="Avengeres",Description="Sci-fi"},
    new Movies(){ID=2,Title="Twilight",Description="Thriller"},
    new Movies(){ID=3,Title="Venom",Description="Sci-fi"},
    new Movies(){ID=4,Title="Bhola",Description="Thriller"},
    new Movies(){ID=5,Title="Jumanji",Description="Adventure"}

};

        public MoviesController(Phase4Day6AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetMovies(int id)
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            var movies = await _context.Movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            return movies;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovies(int id, Movies movies)
        {
            if (id != movies.ID)
            {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movies>> PostMovies(Movies movies)
        {
          if (_context.Movies == null)
          {
              return Problem("Entity set 'Phase4Day6AssignmentDbContext.Movies'  is null.");
          }
            _context.Movies.Add(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovies", new { id = movies.ID }, movies);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesExists(int id)
        {
            return (_context.Movies?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
