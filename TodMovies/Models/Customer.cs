using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodMovies.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name ="Date of Birth")]
        [AgeMin18]
        public DateTime? Birthdate { get; set; }
        
        public bool IsSubscribed { get; set; }
        public MemberShipType MemberShipType { get; set; }

        [ForeignKey("MemberShipType")]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}