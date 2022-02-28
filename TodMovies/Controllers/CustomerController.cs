using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TodMovies.Models;
using TodMovies.ViewModels;

namespace TodMovies.Controllers
{

    public class CustomerController : Controller
    {
        private ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        public ActionResult New()
        {
            var ViewModel = new CustomerViewModel()
            {
                MemberShipTypes = db.MemberShipTypes.ToList()
            };

            return View("CustomerForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel(customer)
                {
                    MemberShipTypes = db.MemberShipTypes.ToList()
                };
                return View("CustomerForm", ViewModel);
            }
            if (customer.Id == 0)
                db.Customers.Add(customer);
            else
            {
                Customer CustomerFromDB = db.Customers.Include(n => n.MemberShipType).Single(n => n.Id == customer.Id);
                CustomerFromDB.Name = customer.Name;
                CustomerFromDB.Birthdate = customer.Birthdate;
                CustomerFromDB.IsSubscribed = customer.IsSubscribed;
                CustomerFromDB.MembershipTypeId = customer.MembershipTypeId;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Details(int id)
        {
            var customer = db.Customers.Include(n => n.MemberShipType).SingleOrDefault(n => n.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.SingleOrDefault(n => n.Id == id);
            if (customer == null)
                return HttpNotFound();

            var ViewModel = new CustomerViewModel(customer)
            {
                MemberShipTypes = db.MemberShipTypes.ToList()
            };
            return View("CustomerForm", ViewModel);
        }

        public ActionResult DeleteUser(int id)
        {
            var CustomerFromDb = db.Customers.Find(id);
            if (CustomerFromDb == null)
                return HttpNotFound();

            db.Customers.Remove(CustomerFromDb);
            db.SaveChanges();

            var customers = db.Customers.Include(c => c.MemberShipType).ToList();
            return RedirectToAction("List", customers);
        }
    }
}