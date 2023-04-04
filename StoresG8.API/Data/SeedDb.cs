
using StoresG8.API.Data;
using StoresG8.Shared.Entities;

namespace StoresG8.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
        }


        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "calzado" });
                _context.Categories.Add(new Category { Name = "Tecnologia" });

            }

            await _context.SaveChangesAsync();
        }

    }
}
