using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
            var products = _context.Products.ToList();

            var viewModel = new DonationFormViewModel
            {
                Products = products,
                Date = DateTime.Now,
                UserId = "a" //TODO: Let's consider for a moment the danger of exposing the UserId to the client... (even if it is within a hidden input)
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
                    Date = DateTime.Now,
                    UserId = "a"//TODO: Let's consider for a moment the danger of exposing the UserId to the client... (even if it is within a hidden input)
                };
                return View("DonationForm", viewModel);
            }

            //Only authenticated users can access this code, thereby, it shouldn't launch
            //an exception unless a hacker is messing around...
            var userInDb = _context.Users.Single(u => u.UserName == User.Identity.Name);

            donation.UserId = userInDb.Id;//TODO: It could be added in a hidden input

            var productInDb = _context.Products.SingleOrDefault(p => p.Id == donation.ProductId);
            if (productInDb != null)
            {
                productInDb.UnitsInStock += donation.Units;
                _context.Donations.Add(donation);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Donations");

        }
    }
}