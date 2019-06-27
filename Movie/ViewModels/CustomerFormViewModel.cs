using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Models.MembershipType> MembershipTypes { get; set; }
        public Models.Customer Customer { get; set; }
    }
}