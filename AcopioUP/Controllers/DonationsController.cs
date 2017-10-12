using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    public class DonationsController : Controller
    {
        // GET: Donations
        public ActionResult Index()
        {

            var viewModel = new DonationFormViewModel();
            return View("DonationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Donation donation)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DonationFormViewModel();
                return View("DonationForm", viewModel);
            }
            return View("DonationForm");
            //if (donation.Id == 0)
            //{
            //    _context.Victims.Add(victim);
            //}
            //else
            //{
            //    var victimInDb = _context.Victims.Single(v => v.Id == victim.Id);
            //    victimInDb.FirstName = victim.FirstName;
            //    victimInDb.LastName = victim.LastName;
            //    victimInDb.Email = victim.Email;
            //}
            //_context.SaveChanges();
            //return RedirectToAction("Index", "Victims");
        }
    }
}