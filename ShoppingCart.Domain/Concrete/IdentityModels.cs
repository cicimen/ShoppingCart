using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingCart.Domain.Entities;
using System;

namespace ShoppingCart.Domain.Concrete
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HomeTown { get; set; }
        public DateTime? BirthDate { get; set; }
        public Address Address { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            //: base("DefaultConnection")
            : base("EFDbContext")
        {
        }
    }
}