using Microsoft.EntityFrameworkCore;
using Stores.Shared.Entities;
using StoresG1.Shared.Entities;
using StoresG8.Shared.Entities;

namespace StoresG8.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
            
        }
     

        public DbSet<Country> Countries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Imigración de la base de datos 
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();

            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();
        }



    }
}
