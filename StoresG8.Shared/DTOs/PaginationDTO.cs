namespace StoresG1.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Id { get; set; }

        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 5; //Modificación de los resultados de la paginación

        public string? Filter { get; set; }

        public string? CountryId { get; set; } //Le agreamos ID a paises,  para a la hora de dale filtrar no nos diera problema a la hora de hacer la busqueda.

        public string? StateId { get; set;} // Le agregamos ID a estados, para a la hora de dale filtrar 

    }
}

