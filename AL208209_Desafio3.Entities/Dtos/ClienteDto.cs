using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL208209_Desafio3.Entities.Dtos
{
    public class ClienteDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Apellido { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public string Email { get; set; } = string.Empty;
    }
}
