using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;
using System.Data.Entity;

namespace Movie.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c=>c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c=>c.Id == id);

            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModels.CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Models.Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer,customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsteller = customer.IsSubscribedToNewsteller;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new ViewModels.CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);


        }
        //private IEnumerable<Models.Customer> GetCustomers()
        //{
            //return new List<Models.Customer>
            //{
            //    new Models.Customer { Id = 1, Name = "Andrei" },
            //    new Models.Customer { Id = 2, Name = "Cristian" }
            //};
        //}
    }
}