using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//sil sonra
using System.Data.Entity;

using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository repository;

        public HomeController(IProductRepository productRepository)
        {
            
            this.repository = productRepository;
        }

        public ActionResult Index()
        {
            ShoppingCart.Domain.Concrete.EFDbContext context = new ShoppingCart.Domain.Concrete.EFDbContext();
            var category = context.Categories.Include(x => x.Offspring.Select(e => e.Offspring)).SingleOrDefault(y=> y.CategoryID ==5);

            var establishments = context.Categories.Where(x => x.Ancestors.Any(y => y.Separation > 3));

            return View(repository.Products.ToList());
        }
	}
}