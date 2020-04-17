using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesAPIController: ControllerBase
    {
        private readonly MvcMovieContext _context;

        public MoviesAPIController(MvcMovieContext context)
		{
            _context = context;
		}

        // GET: MoviesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetListMovies()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: MoviesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movieItem = await _context.Movie.FindAsync(id);

            if (movieItem == null)
            {
                return NotFound();
            }

            return movieItem;
        }

        // PUT: MoviesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!MovieExist(id))
            {
                NotFound();
            }

            return NoContent();
        }

        // POST: MoviesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // DELETE: MoviesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovies(int id)
        {
            var movies = await _context.Movie.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExist(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }


    }
}
