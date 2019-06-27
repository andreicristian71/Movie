using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Movie.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            this.Id = 0;
            this.IsSubscribedToNewsteller = false;
        }
        public CustomerFormViewModel(Models.Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.IsSubscribedToNewsteller = customer.IsSubscribedToNewsteller;
            this.MembershipTypeId = customer.MembershipTypeId;
            this.BirthDate = customer.BirthDate;
        }


        public IEnumerable<Models.MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsteller { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        [Models.Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }


        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Customer";
                return "New Customer";
            }
        }
    }
}