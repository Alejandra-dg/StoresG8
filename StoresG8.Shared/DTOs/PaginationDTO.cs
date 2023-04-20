﻿namespace StoresG1.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Id { get; set; }

        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 3; //Modificación de los resultados de la paginación

        public string? Filter { get; set; }

    }
}

