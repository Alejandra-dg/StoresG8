using StoresG8.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace Stores.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Departamento/Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public ICollection<City>? Cities { get; set; }

        //Con este ID en edición nos permite regresar al 
        public int CountryId { get; set; }

        public Country? Country { get; set; }

        //Contamos ciudades por pais

        [Display(Name = "Ciudades/Municipios")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}

