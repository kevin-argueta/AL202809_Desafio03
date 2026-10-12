using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL208209_Desafio3.Entities.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required double Precio { get; set; }
        public required int Stock { get; set; }

    }
}
