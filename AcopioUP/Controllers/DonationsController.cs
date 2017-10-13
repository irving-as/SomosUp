using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    [Authorize(Roles = RoleNames.CanManageProducts)] //I pressume anyone who manages products can manage donations but it would be nice if there is a role for Collection Centers as well
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

            //TODO: Change this code and show a list of the donations made in the current Collection Center

            var products = _context.Products.ToList();

            var viewModel = new DonationFormViewModel
            {
                Products = products,
                Date = DateTime.Now
            };

            return View("DonationForm", viewModel);
        }

        public ActionResult New()
        {
            var products = _context.Products.ToList();

            var viewModel = new DonationFormViewModel
            {
                Products = products,
                Date = DateTime.Now
            };

            return View("DonationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Donation donation)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DonationFormViewModel
                {
                    Products = _context.Products.ToList(),
                    Date = DateTime.Now
                };
                return View("DonationForm", viewModel);
            }

            var productInDb = _context.Products.SingleOrDefault(p => p.Id == donation.ProductId);
            if (productInDb != null)
            {
                productInDb.UnitsInStock += donation.Units;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Products");

        }
    }
}