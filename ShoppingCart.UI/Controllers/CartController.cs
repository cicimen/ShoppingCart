using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Concrete;
using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Controllers
{
    public class CartController : Controller
    {
        EFCartRepository cartRepository = new EFCartRepository();
        
        private IProductRepository productRepository;

        public CartController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var cart = EFCartRepository.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var product = productRepository.Products.Single(x => x.ProductID == id);
            // Add it to the shopping cart
            var cart = EFCartRepository.GetCart(this.HttpContext);
            cart.AddToCart(product);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // GET: /Store/AddToCart/5
        //public ActionResult AddToCart(int id,int itemCount)
        //{
        //    // Retrieve the album from the database
        //    var product = productRepository.Products.Single(x => x.ProductID == id);
        //    // Add it to the shopping cart
        //    var cart = EFCartRepository.GetCart(this.HttpContext);
        //    cart.AddToCart(product, itemCount);
        //    // Go back to the main store page for more shopping
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            string currentLanguageCode = System.Web.HttpContext.Current.Session["Language"].ToString() == "en" ?"en": "tr" ;

            // Remove the item from the cart
            var cart = EFCartRepository.GetCart(this.HttpContext);
            // Get the name of the album to display confirmation
            string albumName = cartRepository.Carts.Single(x => x.RecordId == id).Product.ProductTranslations.
                FirstOrDefault(x=> x.Language.LanguageCode == currentLanguageCode).ProductName;
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) + currentLanguageCode == "en" ?" has been removed from your shopping cart." : "sepetten çıkarıldı." ,
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = EFCartRepository.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}