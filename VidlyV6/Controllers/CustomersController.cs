using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyV6.Models;

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
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
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
    }
}