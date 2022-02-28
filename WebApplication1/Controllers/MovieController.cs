using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext db;
        public MovieController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public ActionResult MovieIndex()
        {
            var movies = db.Movies.Include(n => n.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var MovieModel = new ViewModels.MovieViewModel()
            {
                Genres = db.Genres.ToList()
            };
            return View("MovieForm",MovieModel);
        }
        public ActionResult EditMovie(int id)
        {
            var MovieFromDb = db.Movies.SingleOrDefault(n => n.Id == id);
            if (MovieFromDb == null)
                return HttpNotFound();

            var MovieModel = new ViewModels.MovieViewModel(MovieFromDb)
            {
                Genres = db.Genres.ToList()
            };
            return View("MovieForm",MovieModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var MovieModel = new ViewModels.MovieViewModel(movie)
                {
                    Genres = db.Genres.ToList()
                };
                return View("MovieForm", MovieModel);
            }
            if (movie.Id == 0)
                db.Movies.Add(movie);
            else
            {
                Movie MovieFromDb = db.Movies.Include(n=>n.Genre).Single(n => n.Id == movie.Id);
                MovieFromDb.Name = movie.Name;
                MovieFromDb.ReleaseTime = movie.ReleaseTime;
                MovieFromDb.DateAddded = movie.DateAddded;
                MovieFromDb.NumberInStock = movie.NumberInStock;
                MovieFromDb.GenreId = movie.GenreId;
            }
            
            db.SaveChanges();
            var movies = db.Movies.Include(n => n.Genre).ToList();
            return View("MovieIndex",movies);
        }
        public ActionResult DeleteMovie(int id)
        {
            var MovieFromDb = db.Movies.Find(id);
            if (MovieFromDb == null)
                return HttpNotFound();

            db.Movies.Remove(MovieFromDb);
            db.SaveChanges();

            var movies = db.Movies.Include(c => c.Genre).ToList();
            return RedirectToAction("MovieIndex", movies);
        }
    }
}
