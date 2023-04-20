using StoresG8.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace StoresG1.Shared.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; } = null!;
    }
}

