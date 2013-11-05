using ShoppingCart.Domain.Entities;
using System.Data.Entity;

namespace ShoppingCart.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}