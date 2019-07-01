using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsteller { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

//        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public int MoviesRentedAtOneTime { get; set; }
    }
}