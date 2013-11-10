using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Entities;

namespace ShoppingCart.UI.Controllers
{
    public class NavController : Controller
    {
        private ICategoryRepository repository;
        public const string LanguageSessionKey = "Language";
        public NavController(ICategoryRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<Category> categories = repository.Categories.Where(x=>x.Parent == null).Select(x => x);
            return PartialView(categories);
        }

        public RedirectResult ChangeLanguage(string ReturnURL = "",string Language = "tr")
        {
            string language;
            if(Session[LanguageSessionKey] != null)
            language = Session[LanguageSessionKey] as string;

            Session[LanguageSessionKey] = Language;
            return RedirectPermanent(ReturnURL);
        }
	}
}