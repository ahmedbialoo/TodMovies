using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodMovies.Models;

namespace TodMovies.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public byte Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [AgeMin18]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribed { get; set; }

        [ForeignKey("MemberShipType")]
        [Display(Name="Membership Type")]
        public byte? MembershipTypeId { get; set; }

        public CustomerViewModel()
        {
            Id = 0;   
        }
        public CustomerViewModel(Customer customer)
        {
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            IsSubscribed = customer.IsSubscribed;
            MembershipTypeId = customer.MembershipTypeId;
        }
    }

}