using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyV6.Models;
using VidlyV6.ViewModels;

namespace VidlyV6.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()//ctor tab
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Save(Customer customer)
        {
            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);//1problem
                //Mapper.Map(customer, customerInDb);//2problem
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.MembershipType = customer.MembershipType;
            }
            //_context.SaveChanges();
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index", "Customers");
        }
        // GET: Customers
        public ViewResult Index()
        {
            //var customers = GetCustomers();//2 end
//            var customers = _context.Customers.ToList();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);//2
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
//        private IEnumerable<Customer> GetCustomers()//2
//        {
//            int cnt = 1;
//            return new List<Customer>
//            {
//                new Customer { Id = cnt++, Name = "John Smith" },
//                new Customer { Id = cnt++, Name = "Mary Williams" },
//                new Customer { Id = cnt++, Name = "Steven Smith" },
//                new Customer { Id = cnt++, Name = "Robi  Williams" },
//                new Customer { Id = cnt++, Name = "jbfdj Smith" },
//                new Customer { Id = cnt++, Name = "Rbjhb Williams" }
//            };
//        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}