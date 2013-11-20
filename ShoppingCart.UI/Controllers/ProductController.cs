using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;
using ShoppingCart.UI.Models;

using ShoppingCart.UI.Helpers;

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
            int productInventory = 0;
            if(string.IsNullOrWhiteSpace(productLinkText))
            {
                return RedirectToAction("Index", "Home", new{page =1});
            }

            var product = productRepository.Products.Where(x => x.ProductURLText == productLinkText).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index", "Home", new { page = 1 });
            }
            ProductAttribute firstProductAttribute = product.ProductAttributes.FirstOrDefault();
            if (firstProductAttribute == null)
            {
                productInventory = product.Inventory;
            }
            else
            {
                List<ProductAttributeValue> firstProductAttributeValues = firstProductAttribute.ProductAttributeValues;
                List<ProductAttributeValueTranslation> firstProductAttributeValueTranslations = new List<ProductAttributeValueTranslation>();

                foreach (ProductAttributeValue productAttributeValue in firstProductAttributeValues)
                {
                    firstProductAttributeValueTranslations.Add(productAttributeValue.ProductAttributeValueTranslations
                        .Where(x => x.Language.LanguageCode == CodeHelpers.GetLanguageCode()).First());
                    productInventory += productAttributeValue.Inventory;
                }
                ViewBag.ProductAttributeValueID = new SelectList(firstProductAttributeValueTranslations, "ProductAttributeValueID", "ProductAttributeValueName");
            }
            ViewBag.ProductInventory = productInventory>10 ? 10 : productInventory ;
            return View(product);

            
        }
	}
}