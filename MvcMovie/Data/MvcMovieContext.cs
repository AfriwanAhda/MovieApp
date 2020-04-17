using System;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        private Func<DbContextOptions<MvcMovieContext>> getRequiredService;

        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options)
        {
        }

        public MvcMovieContext(Func<DbContextOptions<MvcMovieContext>> getRequiredService)
        {
            this.getRequiredService = getRequiredService;
        }

        public DbSet<Movie> Movie { get; set; }
    }
}