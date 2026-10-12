using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL208209_Desafio3.Entities.Dtos
{
    public class ProductoDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El campo {0} debe ser un valor positivo")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int stock { get; set; }
    }
}