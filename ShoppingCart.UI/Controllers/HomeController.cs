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

        private IProductRepository productRepository;

        //TODO: Dışarıdan parametre olarak al bunu
        public int PageSize = 5;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Index(string categoryLinkText , int page =1)
        {          
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productRepository.Products
                .Where(x => categoryLinkText == null || (x.Category.CategoryURLText == categoryLinkText ||x.Category.Parent.CategoryURLText == categoryLinkText ))
                .OrderBy(p => p.DiscountedPrice)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = categoryLinkText == null ? productRepository.Products.Count() : 
                        productRepository.Products.Where(e => (e.Category.CategoryURLText == categoryLinkText ||e.Category.Parent.CategoryURLText ==categoryLinkText )).Count()
                },
                CurrentCategory = categoryLinkText
            };

            return View(model);
        }


        

	}
}