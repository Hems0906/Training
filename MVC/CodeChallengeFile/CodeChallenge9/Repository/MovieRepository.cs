using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeChallenge9.Models;

namespace CodeChallenge9.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository()
        {
            _context = new MoviesDbContext();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return _context.Movies
                .Where(m => m.DateOfRelease.Year == year).ToList();
        }

        public IEnumerable<Movie> GetByDirector(string directorName)
        {
            return _context.Movies
                .Where(m => m.DirectorName == directorName).ToList();
        }
    }
}