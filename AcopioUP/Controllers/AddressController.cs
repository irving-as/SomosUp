using System.Data.Entity;
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
            var collectionCenters = _context.Users.Where(u => u.Address != null).Include(u => u.Address).ToList();
            return View(User.IsInRole(RoleNames.CanCreateAccounts) ? "List" : "ReadOnlyList", collectionCenters);
        }

    }
}