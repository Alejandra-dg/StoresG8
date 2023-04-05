using Microsoft.EntityFrameworkCore;
using Stores.Shared.Entities;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Imigración de la base de datos 
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<State>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();
        }



    }
}
