using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodMovies.Models;

namespace TodMovies.Dtos
{
    public class NewRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}