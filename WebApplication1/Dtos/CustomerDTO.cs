using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DTOS
{
    public class CustomerDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        //[AgeMin18]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribed { get; set; }

        [ForeignKey("MemberShipType")]
        public byte MembershipTypeId { get; set; }
    }
}