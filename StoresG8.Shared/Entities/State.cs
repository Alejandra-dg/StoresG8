using StoresG8.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace StoresG8.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Departamento/Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        // Con este ID es edición nos permita regrasar al 
        public int CountryId { get; set; }

        public ICollection<City>? Cities { get; set; }

        public Country? Country { get; set; }

        //contamos ciudades por pais 
        [Display(Name = "Ciudad/Municipios")]

        public int CitiesNumber => Cities == null ? 0 : Cities.Count;



    }
}
