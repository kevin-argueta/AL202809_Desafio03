using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AL208209_Desafio3.Entities.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public required DateTime FechaPedido { get; set; }
        public required int Cantidad { get; set; }
        public required int ClienteId { get; set; }
        public required int ProductoId { get; set; }
    }
}
