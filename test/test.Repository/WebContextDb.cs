using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Model;

namespace test.Repository
{
    public class WebContextDb : DbContext
    {
        public WebContextDb(): base("name=Model1")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Employees)
                .HasForeignKey(e => e.SalesPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Products)
                .WillCascadeOnDelete(false);
        }
    }
}
