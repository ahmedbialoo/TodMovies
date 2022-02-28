using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using TodMovies.Dtos;
using TodMovies.Models;

namespace TodMovies.Controllers.API
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db;
        public MoviesController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/Movies
        [AllowAnonymous]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = db.Movies
                .Include(n => n.Genre);
            if (!String.IsNullOrWhiteSpace(query))
            {
                var availbleMoviesQuery = moviesQuery.Where(n => n.NumberAvailable != 0);
                moviesQuery = availbleMoviesQuery.Where(n => n.Name.Contains(query));
            }

            var movieDTO = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(movieDTO);
        }

        //GET /api/Movies/id
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = db.Movies.SingleOrDefault(n => n.Id == id);
            if (movieInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movieInDb));
        }

        //POST api/Movies
        [AllowAnonymous]
        public IHttpActionResult PostMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            db.Movies.Add(movie);
            db.SaveChanges();

            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
        }

        //PUT api/Movies/id
        public void PutMovie(int id, MovieDTO movieDTO)
        {
            if (movieDTO == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = db.Movies.SingleOrDefault(n => n.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, movieInDb);
            db.SaveChanges();
        }

        //DELET api/Movies/id
        public void DeleteMovie(int id)
        {
            var movieInDb = db.Movies.SingleOrDefault(n => n.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Movies.Remove(movieInDb);
            db.SaveChanges();
        }
    }
}