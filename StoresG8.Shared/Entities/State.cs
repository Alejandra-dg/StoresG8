using StoresG8.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace Stores.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        // llave 
        public int CountryId { get; set; } 

        [Display(Name = "Departamento/Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public ICollection<City>? Cities { get; set; }
        

        // Cuando tiene el (?) Ignore los Null 
        // Relación entre estados y pais, (Country es el padre esto remplaza el forenkey)
        public Country? Country { get; set; }
    }
}

