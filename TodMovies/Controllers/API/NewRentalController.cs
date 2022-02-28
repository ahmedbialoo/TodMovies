using System;
using System.Linq;
using System.Web.Http;
using TodMovies.Dtos;
using TodMovies.Models;

namespace TodMovies.Controllers.API
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext db;
        public NewRentalController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDTO newRental)
        {
            var customer = db.Customers
                .Single(c => c.Id == newRental.CustomerId);

            var movies = db.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not availble");

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                db.Rentals.Add(rental);
            }

            db.SaveChanges();
            return Ok();
        }
    }
}