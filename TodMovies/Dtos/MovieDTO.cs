using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodMovies.Dtos
{
    public class MovieDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime? ReleaseTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime? DateAddded { get; set; }

        [Range(0, 20)]
        public int NumberInStock { get; set; }

        public GenreDTO genre { get; set; }

        [ForeignKey("Genre")]
        public byte GenreId { get; set; }
    }
}