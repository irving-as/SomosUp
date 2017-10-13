using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    public class CollectionCentersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CollectionCentersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CollectionCenters
        public ActionResult Index()
        {

            var collectionCenters = _context.CollectionCenters.ToList();

            return View("List", collectionCenters);
        }

        public ActionResult New()
        {
            var viewModel = new CollectionCenterFormViewModel();
            return View("CollectionCenterForm", viewModel);
        }

        public ActionResult Edit(int id)
        {

            var collectionCenterInDb = _context.CollectionCenters.Single(c => c.Id == id);

            var viewModel = new CollectionCenterFormViewModel(collectionCenterInDb);
            return View("CollectionCenterForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CollectionCenter collectionCenter)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CollectionCenterFormViewModel(collectionCenter);
                return View("CollectionCenterForm", viewModel);
            }

            if (collectionCenter.Id == 0)
            {
                _context.CollectionCenters.Add(collectionCenter);
            }
            else
            {
                var collectionCenterInDb = _context.CollectionCenters.Single(c => c.Id == collectionCenter.Id);
                collectionCenterInDb.Name = collectionCenter.Name;
                collectionCenterInDb.Address = collectionCenter.Address;
                collectionCenterInDb.PhoneNumber = collectionCenter.PhoneNumber;
                collectionCenterInDb.Lat = collectionCenter.Lat;
                collectionCenterInDb.Long = collectionCenter.Long;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            var collectionCenterInDb = _context.CollectionCenters.SingleOrDefault(c => c.Id == id);
            if (collectionCenterInDb == null)
                return HttpNotFound();

            _context.CollectionCenters.Remove(collectionCenterInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}