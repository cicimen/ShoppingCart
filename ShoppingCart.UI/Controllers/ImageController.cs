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

namespace ShoppingCart.UI.Controllers
{
    public class ImageController : Controller
    {
        private IProductImageRepository repository;

        //TODO: Dışarıdan parametre olarak al bunu
        public int PageSize = 10;
        public ImageController(IProductImageRepository productImageRepository)
        {
            this.repository = productImageRepository;
        }


        public FileContentResult GetImage(int productImageID)
        {
            ProductImage productImage = repository.ProductImages.FirstOrDefault(p => p.ProductImageID == productImageID);
            if (productImage != null)
            {
                return File( System.IO.File.ReadAllBytes(HttpContext.Server.MapPath(productImage.ProductImagePath)), productImage.ProductImageMimeType);
            }
            else
            {
                return null;
            }
        }

	}
}