using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;
using Microsoft.AspNet.Identity;

namespace AcopioUP.Controllers
{
    [Authorize(Roles = RoleNames.CanManageDonations)]
    public class DonationsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DonationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Donations
        public ActionResult Index()
        {
            var userInDb = _context.Users.Single(u => u.UserName == User.Identity.Name);
            var donations = _context.Donations.Include(d => d.Product).Where(d => d.UserId == userInDb.Id).ToList();
            return View("List", donations);
        }

        public ActionResult New()
        {
            var products = _context.Products.Where(p => p.UnitsInStock < p.UnitsNeeded).ToList();

            var viewModel = new DonationFormViewModel
            {
                Products = products,
                Date = DateTime.Now
            };

            return View("DonationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DonationFormViewModel donationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("DonationForm", donationViewModel);
            }

            var productInDb = _context.Products
                .Where(p => p.Id == donationViewModel.ProductId).SingleOrDefault(p => p.UnitsInStock + donationViewModel.Units <= p.UnitsNeeded);
            if (productInDb != null)
            {
                productInDb.UnitsInStock += donationViewModel.Units;
                var donation = new Donation
                {
                    Date = donationViewModel.Date,
                    Description = donationViewModel.Description,
                    ProductId = productInDb.Id,
                    Units = donationViewModel.Units,
                    UserId = User.Identity.GetUserId()
                };
                _context.Donations.Add(donation);
                _context.SaveChanges();
            }
            else
            {
                //TODO:
                throw new NotImplementedException("We must display message showing that the donation contains more products than needed.");
            }

            return RedirectToAction("Index", "Donations");

        }
    }
}