using System.Linq;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    [Authorize(Roles = RoleNames.CanManageBeneficiaries)]
    public class BeneficiariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiariesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Beneficiaries
        [AllowAnonymous]
        public ActionResult Index()
        {
            var beneficiaries = _context.Beneficiaries.ToList();
            if (User.IsInRole(RoleNames.CanManageBeneficiaries))
                return View("List", beneficiaries);

            return View("ReadOnlyList", beneficiaries);

        }

        public ActionResult New()
        {
            var viewModel = new BeneficiaryFormViewModel();

            return View("BeneficiaryForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var beneficiary = _context.Beneficiaries.SingleOrDefault(v => v.Id == id);

            if (beneficiary == null)
                return HttpNotFound();

            var viewModel = new BeneficiaryFormViewModel(beneficiary);
            return View("BeneficiaryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Beneficiary beneficiary)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BeneficiaryFormViewModel(beneficiary);
                return View("BeneficiaryForm", viewModel);
            }

            if (beneficiary.Id == 0)
            {
                _context.Beneficiaries.Add(beneficiary);
            }
            else
            {
                var beneficiaryInDb = _context.Beneficiaries.Single(v => v.Id == beneficiary.Id);
                beneficiaryInDb.FirstName = beneficiary.FirstName;
                beneficiaryInDb.LastName = beneficiary.LastName;
                beneficiaryInDb.Email = beneficiary.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var beneficiaryInDb = _context.Beneficiaries.SingleOrDefault(v => v.Id == id);

            if (beneficiaryInDb == null)
                return HttpNotFound();

            _context.Beneficiaries.Remove(beneficiaryInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}