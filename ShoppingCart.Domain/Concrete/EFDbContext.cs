﻿using ShoppingCart.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ShoppingCart.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductAttributeTranslation> ProductAttributeTranslations { get; set; }
        public DbSet<ProductAttributeValueTranslation> ProductAttributeValueTranslations { get; set; }
        public DbSet<City> Cities{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CategoryNodeConfiguration());
            modelBuilder.Entity<Product>()
                .HasMany(p => p.RelatedProducts)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("RelatedID");
                    m.ToTable("RelatedProduct");
                });
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