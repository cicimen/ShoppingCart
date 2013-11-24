using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Domain.Abstract;
using ShoppingCart.Domain.Concrete;
using ShoppingCart.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ShoppingCart.UI.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private IAddressRepository addressRepository;
        private ICityRepository cityRepository;
        //private IApplicationUserRepository applicationUserRepository;
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public AddressController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }
        public AddressController(UserManager<ApplicationUser> userManager)
        {
            this.addressRepository = new EFAddressRepository();
            this.cityRepository = new EFCityRepository();
            //this.applicationUserRepository = new EFApplicationUserRepository();
            UserManager = userManager;
        }

        public ActionResult Index()
        {
            List<Address> addresses = null;
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                ApplicationUser user = UserManager.FindByName(System.Web.HttpContext.Current.User.Identity.Name);
                if (user != null)
                {
                    addresses = addressRepository.Addresses.Where(x => x.ApplicationUser.Id == user.Id).ToList();
                   
                }
            }
            //TODO: bu gerekmiyecek sanırım.
            if (Request.IsAjaxRequest())
            {
                return PartialView("_AddressTable", addresses);
            }

            return View(addresses);
        }


        [ChildActionOnly]
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(cityRepository.Cities.OrderBy(x=>x.DisplayOrder).ThenBy(x=>x.CityName).ToList() , "CityID", "CityName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Address address)
        {
            
            if (ModelState.IsValid)
            {
                if (this.User != null && this.User.Identity.IsAuthenticated)
                {
                    ApplicationUser user = UserManager.FindByName(System.Web.HttpContext.Current.User.Identity.Name);
                    if (user != null)
                    {
                        address.ApplicationUserId = user.Id;
                        addressRepository.SaveAddress(address);

                        if (Request.IsAjaxRequest())
                        {
                            List<Address> addresses = addressRepository.Addresses.Where(x => x.ApplicationUser.Id == user.Id).ToList();
                            return PartialView("_AddressTable", addresses);
                        }
                        return RedirectToAction("Index", "Address", null);
                    }
                    else
                    { 
                        return RedirectToActionPermanent("Index", "Home");
                    }                
                }
                return RedirectToActionPermanent("Index", "Home");
            }
            else
            {
                return RedirectToActionPermanent("Index", "Home");
            }                

        }

        [ChildActionOnly]
        public ActionResult Edit()
        {
            ViewBag.CityID = new SelectList(cityRepository.Cities.OrderBy(x => x.DisplayOrder).ThenBy(x => x.CityName).ToList(), "CityID", "CityName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Address address)
        {

            if (ModelState.IsValid)
            {
                if (this.User != null && this.User.Identity.IsAuthenticated)
                {
                    ApplicationUser user = UserManager.FindByName(System.Web.HttpContext.Current.User.Identity.Name);
                    if (user != null)
                    {
                        address.ApplicationUserId = user.Id;
                        addressRepository.SaveAddress(address);

                        if (Request.IsAjaxRequest())
                        {
                            List<Address> addresses = addressRepository.Addresses.Where(x => x.ApplicationUser.Id == user.Id).ToList();
                            return PartialView("_AddressTable", addresses);
                        }
                        return RedirectToAction("Index", "Address", null);
                    }
                    else
                    {
                        return RedirectToActionPermanent("Index", "Home");
                    }
                }
                return RedirectToActionPermanent("Index", "Home");
            }
            else
            {
                return RedirectToActionPermanent("Index", "Home");
            }

        }

	}
}