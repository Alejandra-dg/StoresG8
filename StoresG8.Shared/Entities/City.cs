using System.ComponentModel.DataAnnotations;

namespace StoresG8.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        //No se le pone Icollection porque no tiene “hijos”
        [Display(Name = "Ciudades/Municipios")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }

        public State? State { get; set; }

    }
}
