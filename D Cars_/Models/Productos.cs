using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace D_Cars_.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public decimal Precio { get; set; }
        public string? Marca { get; set; }
    }
}
