using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsteller { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        //[Models.Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}