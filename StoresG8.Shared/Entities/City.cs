using System.ComponentModel.DataAnnotations;

namespace Stores.Shared.Entities
{
    public class City
    {
        // llave primary
        public int Id { get; set; }

        public int StateId { get; set; }

        //No se le pone Icollection porque no tiene “hijos”
        [Display(Name = "Ciudades/Municipios")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public State? State { get; set; }
    }
}

