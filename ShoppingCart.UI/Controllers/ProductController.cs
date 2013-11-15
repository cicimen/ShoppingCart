using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;
using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index(string productLinkText)
        {
            if(string.IsNullOrWhiteSpace(productLinkText))
            {
                return RedirectToAction("Index", "Home", new{page =1});
            }

            var product = productRepository.Products.Where(x => x.ProductURLText == productLinkText).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index", "Home", new { page = 1 });
            }
            return View(product);
        }
	}
}