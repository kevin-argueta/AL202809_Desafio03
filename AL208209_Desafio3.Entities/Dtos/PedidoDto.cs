using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL208209_Desafio3.Entities.Dtos
{
    public class PedidoDto
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaPedido { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ProductoId { get; set; }
    }
}
