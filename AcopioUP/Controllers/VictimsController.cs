using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    [Authorize(Roles = RoleNames.CanManageVictims)]
    public class VictimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VictimsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Victims
        [AllowAnonymous]
        public ActionResult Index()
        {
            var victims = _context.Victims.ToList();
            if (User.IsInRole(RoleNames.CanManageVictims))
                return View("List", victims);

            return View("ReadOnlyList", victims);

        }

        public ActionResult New()
        {
            var viewModel = new VictimFormViewModel();

            return View("VictimForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var victim = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victim == null)
                return HttpNotFound();

            var viewModel = new VictimFormViewModel(victim);
            return View("VictimForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Victim victim)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VictimFormViewModel(victim);
                return View("VictimForm", viewModel);
            }

            if (victim.Id == 0)
            {
                _context.Victims.Add(victim);
            }
            else
            {
                var victimInDb = _context.Victims.Single(v => v.Id == victim.Id);
                victimInDb.FirstName = victim.FirstName;
                victimInDb.LastName = victim.LastName;
                victimInDb.Email = victim.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victimInDb == null)
                return HttpNotFound();

            _context.Victims.Remove(victimInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}