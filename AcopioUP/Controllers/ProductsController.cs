using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AcopioUP.Dtos;
using AcopioUP.Models;
using AutoMapper;

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
        public ActionResult Index()
        {
            var products = _context.Products;
            return View(products);
        }

        public ActionResult New()
        {
            var productDto = new ProductDto
            {
                UnitsInStock = 0
            };

            return View("ProductForm", productDto);
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View("ProductForm", Mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public ActionResult Save(ProductDto productDto)
        {
            var productImage = Request.Files["productImage"];

            if (!ModelState.IsValid)
            {
                productDto = new ProductDto
                {
                    UnitsInStock = 0
                };
                return View("ProductForm", productDto);
            }

            if (productDto.Id == 0)
            {
                var imgSrc = SaveImageToLocation(productImage, "~/Content/Images/Products");
                if (imgSrc == null)
                    return View("ProductForm", productDto);

                var product = Mapper.Map<Product>(productDto);
                product.ImgSrc = imgSrc;
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.Id == productDto.Id);
                productInDb.Name = productDto.Name;
                productInDb.UnitsInStock = productDto.UnitsInStock;
                productInDb.UnitsNeeded = productDto.UnitsNeeded;
                const string productImagesPath = "~/Content/Images/Products";
                var imgSrc = SaveImageToLocation(productImage, productImagesPath);
                if (imgSrc != null)
                {
                    DeleteFileFromDisk(productImagesPath, productInDb.ImgSrc);
                    productInDb.ImgSrc = imgSrc;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public string SaveImageToLocation(HttpPostedFileBase productImage, string path)
        {
            var extension = GetImageExtension(productImage);
            if (productImage == null || extension == null)
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