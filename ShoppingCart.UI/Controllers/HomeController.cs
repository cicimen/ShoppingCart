using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//sil sonra
using System.Data.Entity;

using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;
using ShoppingCart.UI.Models;

namespace ShoppingCart.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository repository;

        //TODO: Dışarıdan parametre olarak al bunu
        public int PageSize = 10;
        public HomeController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ActionResult Index(string categoryLinkText , int page =1)
        {
            //ShoppingCart.Domain.Concrete.EFDbContext context = new ShoppingCart.Domain.Concrete.EFDbContext();
            //var category = context.Categories.Include(x => x.Offspring.Select(e => e.Offspring)).SingleOrDefault(y=> y.CategoryID ==5);

            //var establishments = context.Categories.Where(x => x.Ancestors.Any(y => y.Separation > 3));

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(x => categoryLinkText == null || x.Category.CategoryURLText == categoryLinkText)
                .OrderBy(p => p.DiscountedPrice)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categoryLinkText == null ? repository.Products.Count() : repository.Products.Where(e => e.Category.CategoryURLText == categoryLinkText).Count()
                },
                CurrentCategory = categoryLinkText
            };

            return View(model);
        }


        

	}
}