using ShoppingCart.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingCart.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CategoryNodeConfiguration());
        }

    }

    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasOptional(d => d.Parent)
                .WithMany(p => p.Children)
                .Map(d => d.MapKey("ParentId"))
                .WillCascadeOnDelete(false);

            // has many ancestors
            HasMany(p => p.Ancestors)
                .WithRequired(d => d.Offspring)
                .HasForeignKey(d => d.OffspringId)
                .WillCascadeOnDelete(false);

            // has many offspring
            HasMany(p => p.Offspring)
                .WithRequired(d => d.Ancestor)
                .HasForeignKey(d => d.AncestorId)
                .WillCascadeOnDelete(false);
        }
    }

    public class CategoryNodeConfiguration : EntityTypeConfiguration<CategoryNode>
    {
        public CategoryNodeConfiguration()
        {
            ToTable(typeof(CategoryNode).Name);

            HasKey(p => new { p.AncestorId, p.OffspringId });
        }
    }
}