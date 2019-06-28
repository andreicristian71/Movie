using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsteller { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public static class Values
        {
            public static readonly int Unknown = 0;
            public static readonly int PayAsYouGo = 1;
            public static readonly int Monthly = 2;
            public static readonly int Quarterly = 3;
            public static readonly int Yearly = 4;
        }
        

    }
}