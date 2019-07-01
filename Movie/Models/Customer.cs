using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsteller { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        [MaxNumberOfRentedMovies]
        [Display(Name = "How many movies a customer can rent at one time?")]
        public int MoviesRentedAtOneTime { get; set; }
    }
}