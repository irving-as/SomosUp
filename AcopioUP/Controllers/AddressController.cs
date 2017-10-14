using System.Linq;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    [Authorize(Roles = RoleNames.CanCreateAccounts)]
    public class AddressController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AddressController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Address
        [AllowAnonymous]
        public ActionResult Index()
        {
            var addresses = _context.Addresses.ToList();
            if (User.IsInRole(RoleNames.CanCreateAccounts))
                return View("List", addresses);
            return View("ReadOnlyList", addresses);
        }

        public ActionResult New()
        {
            var viewModel = new AddressViewModel();
            return View("AddressForm", viewModel);
        }

        public ActionResult Edit(int id)
        {

            var addressInDb = _context.Addresses.Single(c => c.Id == id);

            var viewModel = new AddressViewModel(addressInDb);
            return View("AddressForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Address address)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddressViewModel(address);
                return View("AddressForm", viewModel);
            }

            if (address.Id == 0)
            {
                _context.Addresses.Add(address);
            }
            else
            {
                var addressInDb = _context.Addresses.Single(c => c.Id == address.Id);
                addressInDb.StreetAddress = address.StreetAddress;
                addressInDb.Lat = address.Lat;
                addressInDb.Long = address.Long;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var addressInDb = _context.Addresses.SingleOrDefault(c => c.Id == id);
            if (addressInDb == null)
                return HttpNotFound();

            _context.Addresses.Remove(addressInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}