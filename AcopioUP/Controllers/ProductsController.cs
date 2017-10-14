using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcopioUP.Models;
using AcopioUP.ViewModels;

namespace AcopioUP.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Products
        [AllowAnonymous]
        public ActionResult Index()
        {
            var products = _context.Products;
            if (User.IsInRole(RoleNames.CanManageProducts))
                return View("List", products);

            return View("ReadOnlyList", products);
        }

        [Authorize(Roles = RoleNames.CanManageProducts)]
        public ActionResult New()
        {
            var productViewModel = new ProductViewModel
            {
                UnitsInStock = 0
            };

            return View("ProductForm", productViewModel);
        }

        [Authorize(Roles = RoleNames.CanManageProducts)]
        public ActionResult Edit(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return HttpNotFound();

            return View("ProductForm", new ProductViewModel(productInDb));
        }

        [Authorize(Roles = RoleNames.CanManageProducts)]
        public ActionResult Delete(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.Id == id);

            if (productInDb == null)
                return HttpNotFound();

            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            DeleteFileFromDisk("~/Content/Images/Products", productInDb.ImgSrc);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageProducts)]
        public ActionResult Save(Product product, HttpPostedFileBase productImage)
        {
            if (!ModelState.IsValid)
            {
                var productViewModel = new ProductViewModel(product);
                return View("ProductForm", productViewModel);
            }

            if (product.Id == 0)
            {
                var imgSrc = SaveImageToLocation(productImage, "~/Content/Images/Products");
                if (imgSrc == null)
                {
                    var productViewModel = new ProductViewModel(product);
                    return View("ProductForm", productViewModel);
                }

                product.ImgSrc = imgSrc;
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.UnitsInStock = product.UnitsInStock;
                productInDb.UnitsNeeded = product.UnitsNeeded;
                const string productImagesPath = "~/Content/Images/Products";
                var imgSrc = SaveImageToLocation(productImage, productImagesPath);
                if (imgSrc != null)
                {
                    DeleteFileFromDisk(productImagesPath, productInDb.ImgSrc);
                    productInDb.ImgSrc = imgSrc;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public string SaveImageToLocation(HttpPostedFileBase productImage, string path)
        {
            if (productImage == null || path == null) return null;
            var extension = GetImageExtension(productImage);
            if (extension == null)
                return null;

            var imageName = CreateRandomFileName(extension);

            var imageFileName = Path.GetFileName(productImage.FileName);
            if (imageFileName == null) return null;

            var fullPaht = Path.Combine(Server.MapPath(path), imageName);
            productImage.SaveAs(fullPaht);
            return imageName;
        }

        private bool DeleteFileFromDisk(string path, string fileName)
        {
            var fullPath = Path.Combine(Server.MapPath(path), fileName);
            if (!System.IO.File.Exists(fullPath)) return false;
            System.IO.File.Delete(fullPath);
            return true;
        }

        private static string CreateRandomFileName(string extension)
        {
            var rand = new Random();
            return rand.Next(0, 9) + rand.Next(0, 9) + rand.Next(0, 9) + rand.Next(0, 9) + DateTime.Now.Ticks + extension;
        }

        private static string GetImageExtension(HttpPostedFileBase file)
        {
            if (!file.ContentType.Contains("image"))
                return null;

            var formats = new[] { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.SingleOrDefault(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}