using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Releaase Date")]
        [DisplayFormat(DataFormatString ="{0:d MMM yyyy}")]
        public DateTime? ReleaseTime = DateTime.Now;

        [Display(Name = "Added Date")]
        public DateTime? DateAddded { get; set; }

        [Range(0, 20)]
        public int? NumberInStock = 0;

        public byte? GenreId { get; set; }

        public MovieViewModel()
        {
            Id = 0;
        }
        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseTime = movie.ReleaseTime;
            DateAddded = movie.DateAddded;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
        public  string Title
        {
            get
            {
                return (Id == 0) ? "New Movie" : "Edit Movie";
            }
        }
    }

}